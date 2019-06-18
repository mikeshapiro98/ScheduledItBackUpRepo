namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "Submitted", c => c.DateTime());
            AddColumn("dbo.EventModels", "RequestStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "RequestStatus");
            DropColumn("dbo.EventModels", "Submitted");
        }
    }
}
