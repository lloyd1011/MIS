using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MIS.Backend.Models
{
    public class MISDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Adviser> Advisers { get; set; }
        public DbSet<AdviserNotification> AdviserNotifications { get; set; }
        public DbSet<AdviserOrganization> AdviserOrganizations { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<CollegeCoordinator> CollegeCoordinators { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Liability> Liabilities { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationRead> NotificationReads { get; set; }
        public DbSet<NotificationReadAdviser> NotificationReadAdvisers { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<RecognizedOrganization> RecognizedOrganizations { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLiability> StudentLiabilities { get; set; }
        public DbSet<StudentPosition> StudentPositions { get; set; }
        public DbSet<Year> Years { get; set; }

    }
}