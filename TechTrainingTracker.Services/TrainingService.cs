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
                    Language = model.Language,
                    DifficultyLevel = model.DifficultyLevel,
                    Cost = model.Cost,
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
                                    Language = e.Language,
                                    DifficultyLevel = e.DifficultyLevel,
                                    Cost = e.Cost,
                                    LearningLocation = e.LearningLocation,
                                    LearningMethod = e.LearningMethod,
                                    Duration = e.Duration,
                                    CompanyID = e.CompanyID
                                }
                        );
                return query.ToArray();        
            }
        }
    }
}
