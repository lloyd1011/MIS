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
                Username = "Noey",
                Password = "1011971",
            };
    
            var officerType = new UserCredential
            {
                Id = Guid.NewGuid().ToString(),
                UserType = "Officer",
                Username = "JinKy",
                Password = "1011971",
            };
            context.UserCredentials.AddOrUpdate(u => u.UserType, studentType);
            context.UserCredentials.AddOrUpdate(u => u.UserType, adviserType);
            context.UserCredentials.AddOrUpdate(u => u.UserType, officerType);

            var cecsType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Engineering and Computing SCiences",
            };
            var citType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Industrial Technology",
            };
            var casType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Arts and Sciences",
            };
            var cteType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Teacher Eductaion",
            };
            var cabeihmType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Accountancy, Business, Economics and International Hospitality Management",
            };
            var conahsType = new College
            {
                Id = Guid.NewGuid().ToString(),
                CollegeName = "College of Nursing and Allied Health Sciences",
            };

            context.Colleges.AddOrUpdate(a => a.CollegeName, cecsType);
            context.Colleges.AddOrUpdate(a => a.CollegeName, citType);
            context.Colleges.AddOrUpdate(a => a.CollegeName, cteType);
            context.Colleges.AddOrUpdate(a => a.CollegeName, casType);
            context.Colleges.AddOrUpdate(a => a.CollegeName, cabeihmType);
            context.Colleges.AddOrUpdate(a => a.CollegeName, conahsType);

            var bsitType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSIT",
                CourseTitle = "Bachelor in Science in Information Technology",
            };
            var bscsType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSCS",
                CourseTitle = "Bachelor in Science in Computer Sciences",
            };
            var bscoeType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSCoE",
                CourseTitle = "Bachelor in Science in Computer Engineering",
            };
            var bsbaType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSBA",
                CourseTitle = "Bachelor in Science in Businees Administration",
            };
            var bshrmType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSHRM",
                CourseTitle = "Bachelor in Science in Hotel Restuarant Management",
            };
            var bsaType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSA",
                CourseTitle = "Bachelor in Science in Accountancy",
            };
            var bstmType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSTM",
                CourseTitle = "Bachelor in Science in Tourism Management",
            };
            var baphrmType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BAPHRM",
                CourseTitle = "Bachelor of Arts in Pschology and Human Resource Management",
            };
            var bscType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSC",
                CourseTitle = "Bachelor in Science in Criminilogy",
            };
            var beedType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BEEd",
                CourseTitle = "Bachelor of Elementary Education",
            };
            var bsedType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSEd",
                CourseTitle = "Bachelor of Secondary Education",
            };
            var bsnType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSN",
                CourseTitle = "Bachelor in Science in Nursing",
            };
            var bsftType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSFT",
                CourseTitle = "Bachelor in Science in Food Technology",
            };
            var bsfType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BSFT",
                CourseTitle = "Bachelor in Science in Fishery Technology",
            };
            var bitType = new Course
            {
                Id = Guid.NewGuid().ToString(),
                CourseAcronym = "BIT",
                CourseTitle = "Bachelor in Industrial Technology",
            };

            context.Courses.AddOrUpdate(b => b.CourseTitle, bsitType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bscsType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bscoeType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsbaType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bshrmType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsaType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, baphrmType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bstmType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bscType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, beedType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsedType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsnType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsftType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bsfType);
            context.Courses.AddOrUpdate(b => b.CourseTitle, bitType);

            var fourthType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "4th Year",
            };
            var firstType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "1th Year",
            };
            var secondType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "2nd Year",
            };
            var thirdType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "3rd Year",
            };
            var fifthType = new Year
            {
                Id = Guid.NewGuid().ToString(),
                YearLevel = "5th Year",
            };
            context.Years.AddOrUpdate(b => b.YearLevel, firstType);
            context.Years.AddOrUpdate(b => b.YearLevel, secondType);
            context.Years.AddOrUpdate(b => b.YearLevel, thirdType);
            context.Years.AddOrUpdate(b => b.YearLevel, fourthType);
            context.Years.AddOrUpdate(b => b.YearLevel, fifthType);

            var eventType = new Event
            {
                Id = Guid.NewGuid().ToString(),
                EventTitle = "CECSGeneral Assembly",
                DateStart = "8:00 AM September 1, 2018",
                DateEnd = "11:00 AM September 1, 2018",
            };
            context.Events.AddOrUpdate(b => b.EventTitle, eventType);

            var student = new Student
            {
                FirstName = "John Lloyd",
                MiddleName = "Vergara",
                LastName = "Dela Vega",
                UserCredential = studentType,
                College = cecsType,
                Course = bsitType,
                Year = fourthType,
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

