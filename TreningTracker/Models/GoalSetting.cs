using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreningTracker.Models
{
    public class GoalSetting
    {
        [Key]
        public int Id { get; set; }  // klucz główny (np. zawsze 1, bo jedna konfiguracja globalna)

        public int DailyStepsGoal { get; set; }      // dzienny cel kroków
        public int WeeklyTrainingsGoal { get; set; } // tygodniowy cel liczby treningów
    }
}
