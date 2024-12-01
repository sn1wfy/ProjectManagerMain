namespace ProjectManager_Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
