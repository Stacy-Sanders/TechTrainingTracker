using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechTrainingTracker.Models.Training;
using TechTrainingTracker.Services;

namespace TechTrainingTracker.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/Training")]
    public class TrainingController : ApiController
    {
        private bool SetStarState(int trainingId, bool newState)
        {
            // Create the service
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrainingService(userId);

            // Get the training course
            var detail = service.GetTrainingById(trainingId);

            // Create the TrainingEdit model instance with the new star state
            var updatedTraining =
                new TrainingEdit
                {
                    TrainingID = detail.TrainingID,
                    CourseName = detail.CourseName,
                    IsStarred = newState,
                    UserID = detail.UserID,
                    InProgress = detail.InProgress,
                    Language = detail.Language,
                    DifficultyLevel = detail.DifficultyLevel,
                    IsSubcriptionRequired = detail.IsSubcriptionRequired,
                    IsFree = detail.IsFree,
                    CourseCost = detail.CourseCost,
                    LearningLocation = detail.LearningLocation,
                    LearningMethod = detail.LearningMethod,
                    Duration = detail.Duration,
                    CompanyID = detail.CompanyID
                };

            // Return a value indicating whether the update succeeded 
            return service.UpdateTraining(updatedTraining);
        }

        [Route("{id}/Star")]
        [HttpPut]
        public bool ToggleStarOn(int id) => SetStarState(id, true);

        [Route("{id}/Star")]
        [HttpDelete]
        public bool ToggleStarOff(int id) => SetStarState(id, false);
    }
}

