﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public enum Level 
    {
        Beginner = 1,
        Intermediate,
        Advanced
    }

    public enum Location 
    {
        Virtual = 1,
        InPerson
    }

    public enum Method
    {
        SelfPaced = 1,
        InstructorLed,
    }

    public class Training
    {
        [Key]
        public int TrainingID { get; set; }

        public Guid AdminID { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        //[ForeignKey(nameof(Skill))]
        //public int SkillID { get; set; }
        //public virtual Skill Skill { get; set; }

        public string Language { get; set; }

        [Display(Name = "Difficulty Level")]
        public Level DifficultyLevel { get; set; }

        public double Cost { get; set; }

        [Display(Name = "Learning Location")]
        public Location LearningLocation { get; set; }

        [Display(Name = "Learning Method")]
        public Method LearningMethod { get; set; }

        public int Duration { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
