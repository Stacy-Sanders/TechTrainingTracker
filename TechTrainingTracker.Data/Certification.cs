using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public class Certification
    {
        [Key]
        public int CertificationID { get; set; }

        [Required, Display(Name = "Certification Name")]
        public string CertificationName { get; set; }

        [Required, Display(Name = "Exam Required?")]
        public bool HasExam { get; set; }

        [Required, Display(Name = "Exam Fee")]
        public double ExamFee { get; set; }

        [Required, Display(Name = "Date Issued")]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Date Expires")]
        public DateTime ExpireDate { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
