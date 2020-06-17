namespace NguyenDuyNam_lab456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Courses_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Courses_Id)
                .Index(t => t.AttendeeId)
                .Index(t => t.Courses_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Courses_Id", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Courses_Id" });
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropTable("dbo.Attendances");
        }
    }
}
