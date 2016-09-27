namespace WebApiTypeScript.Data.AppContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UserId", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "UserId" });
            DropTable("dbo.Courses");
        }
    }
}
