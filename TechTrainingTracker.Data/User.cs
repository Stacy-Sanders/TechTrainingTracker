using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        //public Guid Username { get; set; }

        public Guid AdminID { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName 
        {
            get
            {
               return $"{ FirstName } { LastName }";
            }
        }

        public string Address { get; set; }

        [Required, Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        //[ForeignKey(nameof(Skill))]
        //public int SkillID { get; set; }
        //public virtual Skill Skill { get; set; }
    }
}
