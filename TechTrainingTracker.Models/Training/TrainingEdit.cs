using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;

namespace TechTrainingTracker.Models.Training
{
    public class TrainingEdit
    {
        public int TrainingID { get; set; }

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

        [ForeignKey(nameof(Company)), Display(Name = "Company ID")]
        public int CompanyID { get; set; }
    }
}
