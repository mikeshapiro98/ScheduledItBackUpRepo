namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "StartTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.EventModels", "EndTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.EventModels", "Submitted", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.EventModels", "RequestStatus", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "RequestStatus", c => c.String());
            AlterColumn("dbo.EventModels", "Submitted", c => c.DateTime());
            AlterColumn("dbo.EventModels", "EndTime", c => c.DateTime());
            AlterColumn("dbo.EventModels", "StartTime", c => c.DateTime());
        }
    }
}
