using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrainingTracker.Data;
using TechTrainingTracker.Models.User;

namespace TechTrainingTracker.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    AdminID = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    StreetAddress2 = model.StreetAddress2,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    PortfolioURL = model.PortfolioURL
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .User
                        .Where(e => e.AdminID == _userId)
                        .Select(
                            e =>
                                    new UserListItem
                                    {
                                        UserID = e.UserID,
                                        FirstName = e.FirstName,
                                        LastName = e.LastName,
                                        StreetAddress = e.StreetAddress,
                                        StreetAddress2 = e.StreetAddress2,
                                        City = e.City,
                                        State = e.State,
                                        ZipCode = e.ZipCode,
                                        PhoneNumber = e.PhoneNumber,
                                        EmailAddress = e.EmailAddress,
                                        PortfolioURL = e.PortfolioURL
                                    }
                        );

                return query.ToArray();
            }
        }

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserID == id && e.AdminID == _userId);
                return
                    new UserDetail 
                    { 
                        UserID = entity.UserID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        StreetAddress = entity.StreetAddress,
                        StreetAddress2 = entity.StreetAddress2,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        PhoneNumber = entity.PhoneNumber,
                        EmailAddress = entity.EmailAddress,
                        PortfolioURL = entity.PortfolioURL
                    };
            }
        }

        public bool UpdateUser(UserEdit model) 
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserID == model.UserID && e.AdminID == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.StreetAddress2 = model.StreetAddress2;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.EmailAddress = model.EmailAddress;
                entity.PortfolioURL = model.PortfolioURL;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(int userID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserID == userID && e.AdminID == _userId);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}




