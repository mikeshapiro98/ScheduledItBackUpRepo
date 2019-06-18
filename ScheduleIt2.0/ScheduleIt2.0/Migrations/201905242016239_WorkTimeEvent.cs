namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkTimeEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "Discriminator");
        }
    }
}
