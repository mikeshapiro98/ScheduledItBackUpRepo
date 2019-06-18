namespace ScheduleIt2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbSetForEventModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Message = c.String(),
                        Title = c.String(),
                        AdminId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.EventModels", new[] { "User_Id" });
            DropTable("dbo.EventModels");
        }
    }
}
