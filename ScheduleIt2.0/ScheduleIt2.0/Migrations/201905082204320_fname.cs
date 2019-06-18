namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fname : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Fname", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Fname", c => c.String());
        }
    }
}
