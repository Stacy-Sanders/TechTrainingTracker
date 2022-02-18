using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        public Guid AdminId { get; set; }

        [ForeignKey(nameof(User))]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        public string Language { get; set; }

        [Display(Name = "Is Language considered one of Top Ten most desirable?")]
        public bool IsTopTenDesirability { get; set; }

        [Required, Display(Name = "Skill Level")]
        public string SkillLevel { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Last Update")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
