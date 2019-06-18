namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmailModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailModels",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        FromEmail = c.String(nullable: false),
                        MessageBody = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailModels");
        }
    }
}
