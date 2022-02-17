using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Number of Known Languages")]
        public int KnownLanguages { get; set; }

        [Display(Name ="List known languages separated by a comma.")]
        public string Language { get; set; }

        [Display(Name = "List skill level of each known language separated by a comma.")]
        public string SkillLevel { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Last Update")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
