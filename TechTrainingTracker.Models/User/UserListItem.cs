using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Models.User
{
    public class UserListItem
    {
        public int UserID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Street Address 2")]
        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(5), Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Portfolio URL")]
        public string PortfolioURL { get; set; }
    }
}
