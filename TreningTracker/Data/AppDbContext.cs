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
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<GoalSetting> GoalSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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

            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.ActivityType)
                .WithMany(at => at.TrainingSessions)
                .HasForeignKey(ts => ts.ActivityTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType { Id = 1, Name = "Bieganie" },
                new ActivityType { Id = 2, Name = "Rower" },
                new ActivityType { Id = 3, Name = "Spacer" },
                new ActivityType { Id = 4, Name = "Siłownia" }
            );

            modelBuilder.Entity<GoalSetting>().HasData(
                new GoalSetting { Id = 1, DailyStepsGoal = 10000, WeeklyTrainingsGoal = 3 }
            );
        }
    }
}
