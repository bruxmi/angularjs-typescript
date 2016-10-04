namespace WebApiTypeScript.Data.ApplicationSettingsContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Log", "Level", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Log", "Level", c => c.String(maxLength: 50));
        }
    }
}
