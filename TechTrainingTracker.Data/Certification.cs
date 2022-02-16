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

        public Guid AdminID { get; set; }

        //[ForeignKey(nameof(User))]
        //public int UserID { get; set; }
        //public virtual User User { get; set; }

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

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
