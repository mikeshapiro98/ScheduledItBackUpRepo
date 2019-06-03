namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtotalhours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "TotalHours", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "TotalHours");
        }
    }
}
