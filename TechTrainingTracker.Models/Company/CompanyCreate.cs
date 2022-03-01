using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Models.Company
{
    public class CompanyCreate
    {

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }

        [Display(Name = "Does the company offer free courses?")]
        public bool HasFreeCourses { get; set; }

        [Display(Name = "Does the company offer a paid subscription?")]
        public bool HasPaidSubscription { get; set; }

        [Display(Name = "Cost of subscription")]
        public double? SubscriptionCost { get; set; }

        [Display(Name = "Is a subscription required?")]
        public bool IsSubcriptionRequired { get; set; }

        [Display(Name = "Does the company have an app?")]
        public bool HasApp { get; set; }

        [Display(Name = "Does the company offer accredited courses?")]
        public bool HasAccreditedCourses { get; set; }

        public string Accreditation { get; set; }
    }
}
