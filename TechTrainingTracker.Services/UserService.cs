﻿using System;
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
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUser()
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
                                        Address = e.Address,
                                        PhoneNumber = e.PhoneNumber,
                                        EmailAddress = e.EmailAddress
                                    }
                        );
                return query.ToArray();
            }
        }
    }
}

