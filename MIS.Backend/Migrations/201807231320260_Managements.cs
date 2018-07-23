namespace MIS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Managements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        Venue = c.String(),
                        Date = c.DateTime(nullable: false),
                        EvaluationRating = c.String(),
                        Description = c.String(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        Logo = c.String(),
                        AcademicYear = c.String(),
                        Level = c.String(),
                        College_Id = c.Int(),
                        OrganizationType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colleges", t => t.College_Id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationType_Id)
                .Index(t => t.College_Id)
                .Index(t => t.OrganizationType_Id);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CollegeName = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdviserNotifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Notification = c.String(),
                        NotificationDate = c.String(),
                        Link = c.String(),
                        AdviserOrganization_Id = c.Int(),
                        Liability_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_Id)
                .ForeignKey("dbo.Liabilities", t => t.Liability_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.AdviserOrganization_Id)
                .Index(t => t.Liability_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.AdviserOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThumbNails = c.String(),
                        SchoolYear = c.String(),
                        Adviser_Id = c.Int(),
                        College_Id = c.Int(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_Id)
                .ForeignKey("dbo.Colleges", t => t.College_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Adviser_Id)
                .Index(t => t.College_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.Advisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Picture = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Liabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LiabilityName = c.String(),
                        Date = c.String(),
                        Adviser_Id = c.Int(),
                        Organization_Id = c.Int(),
                        SchoolYear_Id = c.Int(),
                        Semester_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .ForeignKey("dbo.SchoolYears", t => t.SchoolYear_Id)
                .ForeignKey("dbo.Semesters", t => t.Semester_Id)
                .Index(t => t.Adviser_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.SchoolYear_Id)
                .Index(t => t.Semester_Id);
            
            CreateTable(
                "dbo.SchoolYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolYearName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        SrCode = c.String(),
                        CourseId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        ContactNumber = c.String(),
                        EmailAddress = c.String(),
                        CollegeId = c.Int(nullable: false),
                        Picture = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Activity_Id = c.Int(),
                        Organization_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.Activity_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Activity_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.CollegeCoordinators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Picture = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        College_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colleges", t => t.College_Id)
                .Index(t => t.College_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Picture = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        College_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colleges", t => t.College_Id)
                .Index(t => t.College_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        DateStart = c.String(),
                        DateEnd = c.String(),
                        AdviserOrganization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_Id)
                .Index(t => t.AdviserOrganization_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiverId = c.Int(nullable: false),
                        Content = c.String(),
                        DateSent = c.String(),
                        SenderId = c.String(),
                        ReceiverName = c.String(),
                        SenderName = c.String(),
                        SenderStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NotificationReadAdvisers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Adviser_Id = c.Int(),
                        Notification_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_Id)
                .ForeignKey("dbo.Notifications", t => t.Notification_Id)
                .Index(t => t.Adviser_Id)
                .Index(t => t.Notification_Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationName = c.String(),
                        NotificationDate = c.String(),
                        Link = c.String(),
                        AdviserOrganization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_Id)
                .Index(t => t.AdviserOrganization_Id);
            
            CreateTable(
                "dbo.NotificationReads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        studentRead = c.String(),
                        Notification_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notifications", t => t.Notification_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Notification_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Picture = c.String(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.RecognizedOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademciYear = c.String(),
                        Adviser_Id = c.Int(),
                        Organization_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .Index(t => t.Adviser_Id)
                .Index(t => t.Organization_Id);
            
            CreateTable(
                "dbo.StudentLiabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        Liability_Id = c.Int(),
                        Organization_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Liabilities", t => t.Liability_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Liability_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.StudentPositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentLiabilities", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.StudentLiabilities", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.StudentLiabilities", "Liability_Id", "dbo.Liabilities");
            DropForeignKey("dbo.RecognizedOrganizations", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.RecognizedOrganizations", "Adviser_Id", "dbo.Advisers");
            DropForeignKey("dbo.Officers", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.NotificationReads", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.NotificationReads", "Notification_Id", "dbo.Notifications");
            DropForeignKey("dbo.NotificationReadAdvisers", "Notification_Id", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "AdviserOrganization_Id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.NotificationReadAdvisers", "Adviser_Id", "dbo.Advisers");
            DropForeignKey("dbo.Events", "AdviserOrganization_Id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.Deans", "College_Id", "dbo.Colleges");
            DropForeignKey("dbo.CollegeCoordinators", "College_Id", "dbo.Colleges");
            DropForeignKey("dbo.Attendances", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Attendances", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Attendances", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.AdviserNotifications", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.AdviserNotifications", "Liability_Id", "dbo.Liabilities");
            DropForeignKey("dbo.Liabilities", "Semester_Id", "dbo.Semesters");
            DropForeignKey("dbo.Liabilities", "SchoolYear_Id", "dbo.SchoolYears");
            DropForeignKey("dbo.Liabilities", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Liabilities", "Adviser_Id", "dbo.Advisers");
            DropForeignKey("dbo.AdviserNotifications", "AdviserOrganization_Id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.AdviserOrganizations", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.AdviserOrganizations", "College_Id", "dbo.Colleges");
            DropForeignKey("dbo.AdviserOrganizations", "Adviser_Id", "dbo.Advisers");
            DropForeignKey("dbo.Activities", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "OrganizationType_Id", "dbo.OrganizationTypes");
            DropForeignKey("dbo.Organizations", "College_Id", "dbo.Colleges");
            DropIndex("dbo.StudentLiabilities", new[] { "Student_Id" });
            DropIndex("dbo.StudentLiabilities", new[] { "Organization_Id" });
            DropIndex("dbo.StudentLiabilities", new[] { "Liability_Id" });
            DropIndex("dbo.RecognizedOrganizations", new[] { "Organization_Id" });
            DropIndex("dbo.RecognizedOrganizations", new[] { "Adviser_Id" });
            DropIndex("dbo.Officers", new[] { "Organization_Id" });
            DropIndex("dbo.NotificationReads", new[] { "Student_Id" });
            DropIndex("dbo.NotificationReads", new[] { "Notification_Id" });
            DropIndex("dbo.Notifications", new[] { "AdviserOrganization_Id" });
            DropIndex("dbo.NotificationReadAdvisers", new[] { "Notification_Id" });
            DropIndex("dbo.NotificationReadAdvisers", new[] { "Adviser_Id" });
            DropIndex("dbo.Events", new[] { "AdviserOrganization_Id" });
            DropIndex("dbo.Deans", new[] { "College_Id" });
            DropIndex("dbo.CollegeCoordinators", new[] { "College_Id" });
            DropIndex("dbo.Attendances", new[] { "Student_Id" });
            DropIndex("dbo.Attendances", new[] { "Organization_Id" });
            DropIndex("dbo.Attendances", new[] { "Activity_Id" });
            DropIndex("dbo.Liabilities", new[] { "Semester_Id" });
            DropIndex("dbo.Liabilities", new[] { "SchoolYear_Id" });
            DropIndex("dbo.Liabilities", new[] { "Organization_Id" });
            DropIndex("dbo.Liabilities", new[] { "Adviser_Id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "Organization_Id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "College_Id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "Adviser_Id" });
            DropIndex("dbo.AdviserNotifications", new[] { "Student_Id" });
            DropIndex("dbo.AdviserNotifications", new[] { "Liability_Id" });
            DropIndex("dbo.AdviserNotifications", new[] { "AdviserOrganization_Id" });
            DropIndex("dbo.Organizations", new[] { "OrganizationType_Id" });
            DropIndex("dbo.Organizations", new[] { "College_Id" });
            DropIndex("dbo.Activities", new[] { "Organization_Id" });
            DropTable("dbo.Years");
            DropTable("dbo.StudentPositions");
            DropTable("dbo.StudentLiabilities");
            DropTable("dbo.RecognizedOrganizations");
            DropTable("dbo.Officers");
            DropTable("dbo.NotificationReads");
            DropTable("dbo.Notifications");
            DropTable("dbo.NotificationReadAdvisers");
            DropTable("dbo.Messages");
            DropTable("dbo.Events");
            DropTable("dbo.Deans");
            DropTable("dbo.Courses");
            DropTable("dbo.CollegeCoordinators");
            DropTable("dbo.Attendances");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.SchoolYears");
            DropTable("dbo.Liabilities");
            DropTable("dbo.Advisers");
            DropTable("dbo.AdviserOrganizations");
            DropTable("dbo.AdviserNotifications");
            DropTable("dbo.Admins");
            DropTable("dbo.OrganizationTypes");
            DropTable("dbo.Colleges");
            DropTable("dbo.Organizations");
            DropTable("dbo.Activities");
        }
    }
}
