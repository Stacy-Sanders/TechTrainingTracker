using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;
using TechTrainingTracker.Models.Company;

namespace TechTrainingTracker.Services
{
    public class CompanyService
    {
        private readonly Guid _userId;

        public CompanyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompany(CompanyCreate model)
        {
            var entity =
                new Company()
                {
                    AdminID = _userId,
                    CompanyName = model.CompanyName,
                    HasApp = model.HasApp,
                    HasAccreditedCourses = model.HasAccreditedCourses,
                    Accreditation = model.Accreditation
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Companies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompanyListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Companies
                        .Where(e => e.AdminID == _userId)
                        .Select(
                            e =>
                                new CompanyListItem
                                {
                                    CompanyID = e.CompanyID,
                                    CompanyName = e.CompanyName,
                                    HasApp = e.HasApp,
                                    HasAccreditedCourses = e.HasAccreditedCourses,
                                    Accreditation = e.Accreditation
                                }
                            );
                return query.ToArray();
            }
        }

        public CompanyDetail GetCompanyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyID == id && e.AdminID == _userId);
                return
                    new CompanyDetail
                    {
                        CompanyID = entity.CompanyID,
                        CompanyName = entity.CompanyName,
                        HasApp = entity.HasApp,
                        HasAccreditedCourses = entity.HasAccreditedCourses,
                        Accreditation = entity.Accreditation
                    };
            }
        }
    }
}

