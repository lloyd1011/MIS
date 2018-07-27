namespace MIS.Backend.Migrations
{
    using Microsoft.Azure.Mobile.Server.Tables;
    using MIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.MobileServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SqlClient", new EntityTableSqlGenerator());
        }
        protected override void Seed(Models.MobileServiceContext context)
        {

            var studentType = new UserCredential
            {
                Id = Guid.NewGuid().ToString(),
                UserType = "Student",
                Username = "15-02712",
                Password = "101197",
            };
            var adviserType = new UserCredential
            {
                Id = Guid.NewGuid().ToString(),
                UserType = "Adviser",
            };
            var officerType = new UserCredential
            {
                Id = Guid.NewGuid().ToString(),
                UserType = "Officer",
            };
            context.UserCredentials.AddOrUpdate(u => u.UserType, studentType);
            context.UserCredentials.AddOrUpdate(u => u.UserType, adviserType);
            context.UserCredentials.AddOrUpdate(u => u.UserType, officerType);

            var cecsType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Engineering and Computing SCiences",
            };
            context.Colleges.AddOrUpdate(a => a.CollegeName, cecsType);

            var bsitType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseTitle = "Bachelor in Science in Information Technology",
            };
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsitType);

            var yearType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "4th Year",
            };
            context.Years.AddOrUpdate(b => b.YearLevel, yearType);

            var student = new Student
            {
                FirstName = "John Lloyd",
                MiddleName = "Vergara",
                LastName = "Dela Vega",
                UserCredential = studentType,
                College = cecsType,
                Course = bsitType,
                Year = yearType,
                ContactNumber = "09055252022",
                EmailAddress = "delavegajohnlloyd11@gmail.com",
                Status = "Active",
                Id = Guid.NewGuid().ToString(),
            };
            context.Students.AddOrUpdate(u => u.FirstName, student);
            context.SaveChanges();
        }
           
    }
}
