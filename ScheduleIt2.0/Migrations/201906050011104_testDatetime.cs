namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testDatetime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageSystems",
                c => new
                    {
                        MessageID = c.Guid(nullable: false),
                        DateSent = c.DateTime(nullable: false),
                        DateRead = c.DateTime(),
                        MessageTitle = c.String(),
                        Content = c.String(),
                        UnreadMessage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            AlterColumn("dbo.EventModels", "TotalHours", c => c.Time(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventModels", "TotalHours", c => c.DateTime());
            DropTable("dbo.MessageSystems");
        }
    }
}
