using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Models.Company
{
    public class CompanyDetail
    {
        public int CompanyID { get; set; }

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company has an app?")]
        public bool HasApp { get; set; }

        [Display(Name = "Has accredited courses?")]
        public bool HasAccreditedCourses { get; set; }

        public string Accreditation { get; set; }
    }
}
