namespace WebApiTypeScript.Data.ApplicationSettingsContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationSetting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 100),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Key, unique: true);
            
            CreateTable(
                "dbo.ConnectionString",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ProviderName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Exception = c.String(),
                        Level = c.String(maxLength: 50),
                        Logger = c.String(maxLength: 255),
                        Message = c.String(),
                        RequestId = c.String(maxLength: 50),
                        TenantName = c.String(maxLength: 255),
                        Thread = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ConnectionString", new[] { "Name" });
            DropIndex("dbo.ApplicationSetting", new[] { "Key" });
            DropTable("dbo.Log");
            DropTable("dbo.ConnectionString");
            DropTable("dbo.ApplicationSetting");
        }
    }
}
