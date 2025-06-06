using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreningTracker.Models
{
    public class TrainingSession
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Distance { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public int Calories { get; set; }

        public int Steps { get; set; }

        [Required]
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }


    }

}
