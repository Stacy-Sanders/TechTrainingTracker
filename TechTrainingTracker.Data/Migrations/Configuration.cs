namespace TechTrainingTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TechTrainingTracker.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<TechTrainingTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechTrainingTracker.Data.ApplicationDbContext context)
        {
            //context.User.AddOrUpdate(u => u.UserID,
            //    new User() { UserID = 1, FirstName = "Stacy", LastName = "Sanders", StreetAddress = "15078 NW Central Drive", StreetAddress2 = "Apt. 211", City = "Portland", State = "OR", ZipCode = "97229", PhoneNumber = "812-798-8818", EmailAddress = "stacy.sanders081@gmail.com" },
            //    new User() { UserID = 2, FirstName = "Sydney", LastName = "Donato", StreetAddress = "5065 W STATE ROAD 54", City = "Switz City", State = "IN", ZipCode = "47465", PhoneNumber = "812-798-9064", EmailAddress = "sydneydaisy@yahoo.com" }
            //    );

            //context.Certifications.AddOrUpdate(c => c.CertificationID,
            //    new Certification() { UserID = 1, CertificationName = "MTA 98-361 Software Development", HasExam = true, ExamFee = 125, IssueDate = DateTime.Now,  }
            //    );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
