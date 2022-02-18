using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public class Training
    {
        [Key]
        public int TrainingID { get; set; }

        public Guid AdminID { get; set; }

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [DefaultValue(false)]
        public bool IsStarred { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [Required, Display(Name = "Is course currently in progress?")]
        public bool InProgress { get; set; }

        public string Language { get; set; }

        [Display(Name = "Difficulty Level")]
        public string DifficultyLevel { get; set; }

        [Display(Name = "Is a subscription required?")]
        public bool IsSubcriptionRequired { get; set; }

        [Display(Name = "Is the course free?")]
        public bool IsFree { get; set; }

        [Display(Name = "Cost of course")]
        public double CourseCost { get; set; }

        [Display(Name = "Learning Location")]
        public string LearningLocation { get; set; }

        [Display(Name = "Learning Method")]
        public string LearningMethod { get; set; }

        public string Duration { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
