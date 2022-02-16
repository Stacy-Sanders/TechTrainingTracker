using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;

namespace TechTrainingTracker.Models
{
    public class CertificationEdit
    {
        public int CertificationID { get; set; }

        public string CertificationName { get; set; }

        public bool HasExam { get; set; }

        public double ExamFee { get; set; }

        public DateTimeOffset IssueDate { get; set; }

        public DateTimeOffset? ExpireDate { get; set; }

        [ForeignKey(nameof(Company))]
        public int CompanyID { get; set; }
    }
}
