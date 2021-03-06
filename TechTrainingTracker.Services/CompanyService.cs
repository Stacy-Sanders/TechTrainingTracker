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
                    CompanyWebsite = model.CompanyWebsite,
                    HasFreeCourses = model.HasFreeCourses,
                    HasPaidSubscription = model.HasPaidSubscription,
                    SubscriptionCost = model.SubscriptionCost,
                    IsSubcriptionRequired = model.IsSubcriptionRequired,
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
                                    CompanyWebsite = e.CompanyWebsite,
                                    HasPaidSubscription = e.HasPaidSubscription,
                                    SubscriptionCost = e.SubscriptionCost,
                                    IsSubcriptionRequired = e.IsSubcriptionRequired,
                                    HasFreeCourses = e.HasFreeCourses,
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
                        CompanyWebsite = entity.CompanyWebsite,
                        HasFreeCourses = entity.HasFreeCourses,
                        HasPaidSubscription = entity.HasPaidSubscription,
                        SubscriptionCost = entity.SubscriptionCost,
                        IsSubcriptionRequired = entity.IsSubcriptionRequired,
                        HasApp = entity.HasApp,
                        HasAccreditedCourses = entity.HasAccreditedCourses,
                        Accreditation = entity.Accreditation
                    };
            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyID == model.CompanyID && e.AdminID == _userId);

                entity.CompanyName = model.CompanyName;
                entity.CompanyWebsite = model.CompanyWebsite;
                entity.HasFreeCourses = model.HasFreeCourses;
                entity.HasPaidSubscription = model.HasPaidSubscription;
                entity.SubscriptionCost = model.SubscriptionCost;
                entity.IsSubcriptionRequired = model.IsSubcriptionRequired;
                entity.HasApp = model.HasApp;
                entity.HasAccreditedCourses = model.HasAccreditedCourses;
                entity.Accreditation = model.Accreditation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCompany(int companyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyID == companyID && e.AdminID == _userId);

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

