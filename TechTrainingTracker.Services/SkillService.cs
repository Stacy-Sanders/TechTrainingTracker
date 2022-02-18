using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;
using TechTrainingTracker.Models.Skill;

namespace TechTrainingTracker.Services
{
    public class SkillService
    {
        private readonly Guid _userId;

        public SkillService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSkill(SkillCreate model)
        {
            var entity =
                new Skill()
                {
                    AdminId = _userId,
                    UserID = model.UserID,
                    Language = model.Language,
                    IsTopTenDesirability = model.IsTopTenDesirability,
                    SkillLevel = model.SkillLevel,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Skills.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SkillListItem> GetSkills()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Skills
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new SkillListItem
                                {
                                    SkillID = e.SkillID,
                                    UserID = e.UserID,
                                    Language = e.Language,
                                    IsTopTenDesirability = e.IsTopTenDesirability,
                                    SkillLevel = e.SkillLevel,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public SkillDetail GetSkillByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillID == id && e.AdminId == _userId);
                return
                    new SkillDetail
                    {
                        SkillID = entity.SkillID,
                        UserID = entity.UserID,
                        Language = entity.Language,
                        IsTopTenDesirability = entity.IsTopTenDesirability,
                        SkillLevel = entity.SkillLevel,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateSkill(SkillEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillID == model.SkillID && e.AdminId == _userId);

                entity.UserID = model.UserID;
                entity.Language = model.Language;
                entity.IsTopTenDesirability = model.IsTopTenDesirability;
                entity.SkillLevel = model.SkillLevel;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSkill(int skillID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Skills
                        .Single(e => e.SkillID == skillID && e.AdminId == _userId);

                ctx.Skills.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}