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
    public class CertificationCreate
    {
        [Required, Display(Name = "Certification Name")]
        public string CertificationName { get; set; }

        [Required, Display(Name = "Exam Required?")]
        public bool HasExam { get; set; }

        [Required, Display(Name = "Exam Fee ($USD)")]
        public double ExamFee { get; set; }

        [Required, Display(Name = "Issued")]
        public DateTimeOffset IssueDate { get; set; }

        [Display(Name = "Expires")]
        public DateTimeOffset? ExpireDate { get; set; }

        [ForeignKey(nameof(Company)), Display(Name = "Company ID")]
        public int CompanyID { get; set; }
    }
}
