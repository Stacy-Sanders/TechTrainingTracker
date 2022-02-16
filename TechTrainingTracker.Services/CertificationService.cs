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
                    ExpireDate = model.ExpireDate,
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
                                    ExpireDate = e.ExpireDate,
                                    CompanyID = e.CompanyID
                                }
                        );
                return query.ToArray();
            }
        }

        public CertificationDetail GetCertificationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Certifications
                        .Single(e => e.CertificationID == id && e.AdminID == _userId);
                return
                    new CertificationDetail
                    {
                        CertificationID = entity.CertificationID,
                        CertificationName = entity.CertificationName,
                        HasExam = entity.HasExam,
                        ExamFee = entity.ExamFee,
                        IssueDate = entity.IssueDate,
                        ExpireDate = entity.ExpireDate,
                        CompanyID = entity.CompanyID
                    };
            }
        }

        public bool UpdateCertification(CertificationEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Certifications
                        .Single(e => e.CertificationID == model.CertificationID && e.AdminID == _userId);

                entity.CertificationName = model.CertificationName;
                entity.HasExam = model.HasExam;
                entity.ExamFee = model.ExamFee;
                entity.IssueDate = model.IssueDate;
                entity.ExpireDate = model.ExpireDate;
                entity.CompanyID = model.CompanyID;

                return ctx.SaveChanges() == 1;
            }
        }

        public  bool DeleteCertification(int certificationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Certifications
                        .Single(e => e.CertificationID == certificationID && e.AdminID == _userId);

                ctx.Certifications.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

       
