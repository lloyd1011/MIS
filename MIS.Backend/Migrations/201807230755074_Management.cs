namespace MIS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Management : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        activityName = c.String(),
                        venue = c.String(),
                        date = c.DateTime(nullable: false),
                        evaluationRating = c.String(),
                        description = c.String(),
                        Organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .Index(t => t.Organization_id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        organizationName = c.String(),
                        logo = c.String(),
                        academicYear = c.String(),
                        level = c.String(),
                        College_id = c.Int(),
                        OrganizationType_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Colleges", t => t.College_id)
                .ForeignKey("dbo.OrganizationTypes", t => t.OrganizationType_id)
                .Index(t => t.College_id)
                .Index(t => t.OrganizationType_id);
            
            CreateTable(
                "dbo.Colleges",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        college = c.String(),
                        logo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrganizationTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        organizationType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        picture = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AdviserNotifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        notification = c.String(),
                        notificationDate = c.String(),
                        link = c.String(),
                        AdviserOrganization_id = c.Int(),
                        Liability_id = c.Int(),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_id)
                .ForeignKey("dbo.Liabilities", t => t.Liability_id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .Index(t => t.AdviserOrganization_id)
                .Index(t => t.Liability_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.AdviserOrganizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MyProperty = c.Int(nullable: false),
                        thumbNails = c.String(),
                        schoolYear = c.String(),
                        Adviser_id = c.Int(),
                        College_id = c.Int(),
                        Organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_id)
                .ForeignKey("dbo.Colleges", t => t.College_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .Index(t => t.Adviser_id)
                .Index(t => t.College_id)
                .Index(t => t.Organization_id);
            
            CreateTable(
                "dbo.Advisers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        picture = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Liabilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        liabilityName = c.String(),
                        Date = c.String(),
                        Adviser_id = c.Int(),
                        Organization_id = c.Int(),
                        SchoolYear_id = c.Int(),
                        Semester_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .ForeignKey("dbo.SchoolYears", t => t.SchoolYear_id)
                .ForeignKey("dbo.Semesters", t => t.Semester_id)
                .Index(t => t.Adviser_id)
                .Index(t => t.Organization_id)
                .Index(t => t.SchoolYear_id)
                .Index(t => t.Semester_id);
            
            CreateTable(
                "dbo.SchoolYears",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        schoolYear = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        semester = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        srCode = c.String(),
                        courseId = c.Int(nullable: false),
                        yearId = c.Int(nullable: false),
                        contactNumber = c.String(),
                        emailAddress = c.String(),
                        collegeId = c.Int(nullable: false),
                        picture = c.String(),
                        password = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Activity_id = c.Int(),
                        Organization_id = c.Int(),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Activities", t => t.Activity_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .Index(t => t.Activity_id)
                .Index(t => t.Organization_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.CollegeCoordinators",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        picture = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        College_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Colleges", t => t.College_id)
                .Index(t => t.College_id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        courseName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Deans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        picture = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        College_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Colleges", t => t.College_id)
                .Index(t => t.College_id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        eventTitle = c.String(),
                        dateStart = c.String(),
                        dateEnd = c.String(),
                        AdviserOrganization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_id)
                .Index(t => t.AdviserOrganization_id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        receiverId = c.Int(nullable: false),
                        content = c.String(),
                        dateSent = c.String(),
                        senderId = c.String(),
                        receiverName = c.String(),
                        senderName = c.String(),
                        senderStatus = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.NotificationReadAdvisers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        Adviser_id = c.Int(),
                        Notification_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_id)
                .ForeignKey("dbo.Notifications", t => t.Notification_id)
                .Index(t => t.Adviser_id)
                .Index(t => t.Notification_id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        notification = c.String(),
                        NotificationDate = c.String(),
                        link = c.String(),
                        AdviserOrganization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AdviserOrganizations", t => t.AdviserOrganization_id)
                .Index(t => t.AdviserOrganization_id);
            
            CreateTable(
                "dbo.NotificationReads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        studentRead = c.String(),
                        Notification_id = c.Int(),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Notifications", t => t.Notification_id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .Index(t => t.Notification_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.Officers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        middleName = c.String(),
                        lastName = c.String(),
                        userName = c.String(),
                        password = c.String(),
                        picture = c.String(),
                        Organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .Index(t => t.Organization_id);
            
            CreateTable(
                "dbo.RecognizedOrganizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        academciYear = c.String(),
                        Adviser_id = c.Int(),
                        Organization_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Advisers", t => t.Adviser_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .Index(t => t.Adviser_id)
                .Index(t => t.Organization_id);
            
            CreateTable(
                "dbo.StudentLiabilities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(),
                        Liability_id = c.Int(),
                        Organization_id = c.Int(),
                        Student_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Liabilities", t => t.Liability_id)
                .ForeignKey("dbo.Organizations", t => t.Organization_id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .Index(t => t.Liability_id)
                .Index(t => t.Organization_id)
                .Index(t => t.Student_id);
            
            CreateTable(
                "dbo.StudentPositions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        position = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        year = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentLiabilities", "Student_id", "dbo.Students");
            DropForeignKey("dbo.StudentLiabilities", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.StudentLiabilities", "Liability_id", "dbo.Liabilities");
            DropForeignKey("dbo.RecognizedOrganizations", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.RecognizedOrganizations", "Adviser_id", "dbo.Advisers");
            DropForeignKey("dbo.Officers", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.NotificationReads", "Student_id", "dbo.Students");
            DropForeignKey("dbo.NotificationReads", "Notification_id", "dbo.Notifications");
            DropForeignKey("dbo.NotificationReadAdvisers", "Notification_id", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "AdviserOrganization_id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.NotificationReadAdvisers", "Adviser_id", "dbo.Advisers");
            DropForeignKey("dbo.Events", "AdviserOrganization_id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.Deans", "College_id", "dbo.Colleges");
            DropForeignKey("dbo.CollegeCoordinators", "College_id", "dbo.Colleges");
            DropForeignKey("dbo.Attendances", "Student_id", "dbo.Students");
            DropForeignKey("dbo.Attendances", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.Attendances", "Activity_id", "dbo.Activities");
            DropForeignKey("dbo.AdviserNotifications", "Student_id", "dbo.Students");
            DropForeignKey("dbo.AdviserNotifications", "Liability_id", "dbo.Liabilities");
            DropForeignKey("dbo.Liabilities", "Semester_id", "dbo.Semesters");
            DropForeignKey("dbo.Liabilities", "SchoolYear_id", "dbo.SchoolYears");
            DropForeignKey("dbo.Liabilities", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.Liabilities", "Adviser_id", "dbo.Advisers");
            DropForeignKey("dbo.AdviserNotifications", "AdviserOrganization_id", "dbo.AdviserOrganizations");
            DropForeignKey("dbo.AdviserOrganizations", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.AdviserOrganizations", "College_id", "dbo.Colleges");
            DropForeignKey("dbo.AdviserOrganizations", "Adviser_id", "dbo.Advisers");
            DropForeignKey("dbo.Activities", "Organization_id", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "OrganizationType_id", "dbo.OrganizationTypes");
            DropForeignKey("dbo.Organizations", "College_id", "dbo.Colleges");
            DropIndex("dbo.StudentLiabilities", new[] { "Student_id" });
            DropIndex("dbo.StudentLiabilities", new[] { "Organization_id" });
            DropIndex("dbo.StudentLiabilities", new[] { "Liability_id" });
            DropIndex("dbo.RecognizedOrganizations", new[] { "Organization_id" });
            DropIndex("dbo.RecognizedOrganizations", new[] { "Adviser_id" });
            DropIndex("dbo.Officers", new[] { "Organization_id" });
            DropIndex("dbo.NotificationReads", new[] { "Student_id" });
            DropIndex("dbo.NotificationReads", new[] { "Notification_id" });
            DropIndex("dbo.Notifications", new[] { "AdviserOrganization_id" });
            DropIndex("dbo.NotificationReadAdvisers", new[] { "Notification_id" });
            DropIndex("dbo.NotificationReadAdvisers", new[] { "Adviser_id" });
            DropIndex("dbo.Events", new[] { "AdviserOrganization_id" });
            DropIndex("dbo.Deans", new[] { "College_id" });
            DropIndex("dbo.CollegeCoordinators", new[] { "College_id" });
            DropIndex("dbo.Attendances", new[] { "Student_id" });
            DropIndex("dbo.Attendances", new[] { "Organization_id" });
            DropIndex("dbo.Attendances", new[] { "Activity_id" });
            DropIndex("dbo.Liabilities", new[] { "Semester_id" });
            DropIndex("dbo.Liabilities", new[] { "SchoolYear_id" });
            DropIndex("dbo.Liabilities", new[] { "Organization_id" });
            DropIndex("dbo.Liabilities", new[] { "Adviser_id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "Organization_id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "College_id" });
            DropIndex("dbo.AdviserOrganizations", new[] { "Adviser_id" });
            DropIndex("dbo.AdviserNotifications", new[] { "Student_id" });
            DropIndex("dbo.AdviserNotifications", new[] { "Liability_id" });
            DropIndex("dbo.AdviserNotifications", new[] { "AdviserOrganization_id" });
            DropIndex("dbo.Organizations", new[] { "OrganizationType_id" });
            DropIndex("dbo.Organizations", new[] { "College_id" });
            DropIndex("dbo.Activities", new[] { "Organization_id" });
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
