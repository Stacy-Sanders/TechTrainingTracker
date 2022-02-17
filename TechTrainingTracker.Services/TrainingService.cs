using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;
using TechTrainingTracker.Models.Training;

namespace TechTrainingTracker.Services
{
    public class TrainingService
    {
        private readonly Guid _userId;

        public TrainingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTraining(TrainingCreate model)
        {
            var entity =
                new Training()
                {
                    AdminID = _userId,
                    CourseName = model.CourseName,
                    UserID = model.UserID,
                    Language = model.Language,
                    DifficultyLevel = model.DifficultyLevel,
                    IsSubcriptionRequired = model.IsSubcriptionRequired,
                    IsFree = model.IsFree,
                    CourseCost = model.CourseCost,
                    LearningLocation = model.LearningLocation,
                    LearningMethod = model.LearningMethod,
                    Duration = model.Duration,
                    CompanyID = model.CompanyID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trainings.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<TrainingListItem> GetTrainings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trainings
                        .Where(e => e.AdminID == _userId)
                        .Select(
                            e =>
                                new TrainingListItem
                                {
                                    TrainingID = e.TrainingID,
                                    CourseName = e.CourseName,
                                    UserID = e.UserID,
                                    Language = e.Language,
                                    DifficultyLevel = e.DifficultyLevel,
                                    IsSubcriptionRequired = e.IsSubcriptionRequired,
                                    IsFree = e.IsFree,
                                    CourseCost = e.CourseCost,
                                    LearningLocation = e.LearningLocation,
                                    LearningMethod = e.LearningMethod,
                                    Duration = e.Duration,
                                    CompanyID = e.CompanyID
                                }
                        );
                return query.ToArray();        
            }
        }

        public TrainingDetail GetTrainingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trainings
                        .Single(e => e.TrainingID == id && e.AdminID == _userId);
                return
                    new TrainingDetail
                    {
                        TrainingID = entity.TrainingID,
                        CourseName = entity.CourseName,
                        UserID = entity.UserID,
                        Language = entity.Language,
                        DifficultyLevel = entity.DifficultyLevel,
                        IsSubcriptionRequired = entity.IsSubcriptionRequired,
                        IsFree = entity.IsFree,
                        CourseCost = entity.CourseCost,
                        LearningLocation = entity.LearningLocation,
                        LearningMethod = entity.LearningMethod,
                        Duration = entity.Duration,
                        CompanyID = entity.CompanyID
                    };
            }
        }

        public bool UpdateTraining(TrainingEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trainings
                        .Single(e => e.TrainingID == model.TrainingID && e.AdminID == _userId);

                entity.CourseName = model.CourseName;
                entity.Language = model.Language;
                entity.UserID = model.UserID;
                entity.DifficultyLevel = model.DifficultyLevel;
                entity.IsSubcriptionRequired = model.IsSubcriptionRequired;
                entity.IsFree = model.IsFree;
                entity.CourseCost = model.CourseCost;
                entity.LearningLocation = model.LearningLocation;
                entity.LearningMethod = model.LearningMethod;
                entity.Duration = model.Duration;
                entity.CompanyID = model.CompanyID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTraining(int trainingID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trainings
                        .Single(e => e.TrainingID == trainingID && e.AdminID == _userId);

                ctx.Trainings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
