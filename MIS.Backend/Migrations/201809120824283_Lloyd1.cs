namespace MIS.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lloyd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Course_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "Course_Id");
            AddForeignKey("dbo.Students", "Course_Id", "dbo.Courses", "Id");
            DropColumn("dbo.Students", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Course", c => c.String());
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropColumn("dbo.Students", "Course_Id");
        }
    }
}
