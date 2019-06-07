namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheriteventmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventModels", "MessageID", c => c.Guid());
            AddColumn("dbo.EventModels", "DateSent", c => c.DateTime());
            AddColumn("dbo.EventModels", "DateRead", c => c.DateTime());
            AddColumn("dbo.EventModels", "MessageTitle", c => c.String());
            AddColumn("dbo.EventModels", "Content", c => c.String());
            AddColumn("dbo.EventModels", "UnreadMessage", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventModels", "UnreadMessage");
            DropColumn("dbo.EventModels", "Content");
            DropColumn("dbo.EventModels", "MessageTitle");
            DropColumn("dbo.EventModels", "DateRead");
            DropColumn("dbo.EventModels", "DateSent");
            DropColumn("dbo.EventModels", "MessageID");
        }
    }
}
