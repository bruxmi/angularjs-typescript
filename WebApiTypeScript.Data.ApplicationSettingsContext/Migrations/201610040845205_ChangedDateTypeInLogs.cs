namespace WebApiTypeScript.Data.ApplicationSettingsContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDateTypeInLogs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Log", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Log", "Date", c => c.DateTime(nullable: false));
        }
    }
}
