namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalhour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "TotalHour", c => c.DateTime());
            DropColumn("dbo.EventModels", "TotalHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventModels", "TotalHours", c => c.DateTime());
            DropColumn("dbo.EventModels", "TotalHour");
        }
    }
}
