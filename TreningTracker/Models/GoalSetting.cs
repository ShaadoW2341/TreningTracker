﻿using System;
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
        public int Id { get; set; }
        public int DailyStepsGoal { get; set; }
        public int WeeklyTrainingsGoal { get; set; }
    }
}
