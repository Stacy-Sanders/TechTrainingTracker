using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;
using TechTrainingTracker.Models;

namespace TechTrainingTracker.Services
{
    public class CertificationService
    {
        private readonly Guid _userId;

        public CertificationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCertification(CertificationCreate model)
        {
            var entity =
                new Certification()
                {
                    AdminID = _userId,
                    CertificationName = model.CertificationName,
                    HasExam = model.HasExam,
                    ExamFee = model.ExamFee,
                    IssueDate = model.IssueDate,
                    ExpireDate = model.ExprireDate,
                    CompanyID = model.CompanyID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Certifications.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CertificationListItem> GetCertifications()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Certifications
                        .Where(e => e.AdminID == _userId)
                        .Select(
                            e =>
                                new CertificationListItem
                                {
                                    CertificationID = e.CertificationID,
                                    CertificationName = e.CertificationName,
                                    HasExam = e.HasExam,
                                    ExamFee = e.ExamFee,
                                    IssueDate = e.IssueDate,
                                    ExprireDate = e.ExpireDate,
                                    CompanyID = e.CompanyID
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
