using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Models.Skill
{
    public class SkillCreate
    {
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public string Language { get; set; }

        [Display(Name = "Is Language considered one of Top Ten most desirable?")]
        public bool IsTopTenDesirability { get; set; }

        [Display(Name = "Skill Level")]
        public string SkillLevel { get; set; }

    }
}
