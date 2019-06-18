namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EventModels", "TotalHours", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "TotalHours", c => c.DateTime());
        }
    }
}
