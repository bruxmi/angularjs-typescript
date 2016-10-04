namespace WebApiTypeScript.Data.ApplicationSettingsContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Log", "TimeStamp", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Log", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Log", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Log", "TimeStamp");
        }
    }
}
