using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;

namespace TechTrainingTracker.Models
{
    public class CertificationListItem
    {

        public int CertificationID { get; set; }

        [Display(Name = "Certification Name")]
        public string CertificationName { get; set; }

        [Display(Name = "Issued")]
        public DateTimeOffset IssueDate { get; set; }

        [Display(Name = "Expires")]
        public DateTimeOffset? ExprireDate { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
    }
}
