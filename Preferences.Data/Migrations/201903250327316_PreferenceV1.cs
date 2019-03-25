namespace Preferences.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreferenceV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Preferences.CustomerPreferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        TemplateId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        Repeat = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Preferences.CustomerPreferences");
        }
    }
}
