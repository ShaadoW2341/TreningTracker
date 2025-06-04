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

        [Required]  // Data treningu jest wymagana
        public DateTime Date { get; set; }

        [Required]  // Dystans wymagany (może być zero dla aktywności bez dystansu, np. siłownia)
        public double Distance { get; set; }  // w kilometrach

        [Required]
        public TimeSpan Duration { get; set; }  // czas trwania treningu

        public int Calories { get; set; }  // spalone kalorie (0 lub więcej)

        public int Steps { get; set; }  // liczba kroków (0 jeśli nie dotyczy)

        // Relacja do typu aktywności (wiele TrainingSession do jednego ActivityType)
        [Required]
        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }

        // Relacja N:M do tagów - trening może mieć wiele tagów
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }

}
