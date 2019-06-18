namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "StartTime", c => c.DateTime());
            AlterColumn("dbo.EventModels", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EventModels", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
