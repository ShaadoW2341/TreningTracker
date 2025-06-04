using System.Collections.Generic;
using System.Configuration;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TreningTracker.Models;

namespace TreningTracker.Data
{
    public class AppDbContext : DbContext
    {
        // DbSety odpowiadające tabelom
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<GoalSetting> GoalSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Wczytanie parametrów połączenia z pliku appsettings.json
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration config = configBuilder.Build();

            string connStr = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API konfiguracja modelu:

            // Relacja 1:N między TrainingSession a ActivityType (jeden typ -> wiele treningów)
            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.ActivityType)
                .WithMany(at => at.TrainingSessions)
                .HasForeignKey(ts => ts.ActivityTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja N:M między TrainingSession a Tag (wiele treningów ma wiele tagów)
            modelBuilder.Entity<TrainingSession>()
                .HasMany(ts => ts.Tags)
                .WithMany(tag => tag.TrainingSessions)
                .UsingEntity(j => j.ToTable("TrainingSessionTags"));  // nazwa tabeli pośredniej

            // Opcjonalnie: można zdefiniować dodatkowe właściwości tabeli pośredniej lub klucz główny, 
            // ale EF Core automatycznie utworzy klucz złożony (TrainingSessionId + TagId).

            // Seed (dane początkowe) dla tabeli ActivityTypes
            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Bieganie" },
                new ActivityType { Id = 2, Name = "Rower" },
                new ActivityType { Id = 3, Name = "Spacer" },
                new ActivityType { Id = 4, Name = "Siłownia" }
            );

            // Seed dla tabeli GoalSettings (domyślne cele: 10000 kroków dziennie, 3 treningi tygodniowo)
            modelBuilder.Entity<GoalSetting>().HasData(
                new GoalSetting { Id = 1, DailyStepsGoal = 10000, WeeklyTrainingsGoal = 3 }
            );

            // Uwaga: domyślnie klucze główne typu int są autoinkrementujące (serial w Postgres).
            // W przypadku seedingu, Id są podawane na sztywno, aby zachować spójność powiązań.
        }
    }
}
