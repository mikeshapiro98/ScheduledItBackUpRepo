namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Double : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Fname");
            DropColumn("dbo.AspNetUsers", "Lname");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "EmergencyContact");
            DropColumn("dbo.AspNetUsers", "Status");
            DropColumn("dbo.AspNetUsers", "StartDate");
            DropColumn("dbo.AspNetUsers", "EndDate");
            DropColumn("dbo.AspNetUsers", "Hours");
            DropColumn("dbo.AspNetUsers", "SickDays");
            DropColumn("dbo.AspNetUsers", "Notes");
            DropColumn("dbo.AspNetUsers", "TimeOffEvents");
            DropColumn("dbo.AspNetUsers", "AdminNotes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AdminNotes", c => c.String());
            AddColumn("dbo.AspNetUsers", "TimeOffEvents", c => c.String());
            AddColumn("dbo.AspNetUsers", "Notes", c => c.String());
            AddColumn("dbo.AspNetUsers", "SickDays", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Hours", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Status", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmergencyContact", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Lname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Fname", c => c.String());
        }
    }
}
