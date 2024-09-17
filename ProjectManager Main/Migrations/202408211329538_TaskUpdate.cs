namespace ProjectManager_Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "ProjectId", c => c.Guid(nullable: false));
            DropColumn("dbo.Tasks", "ProjctId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "ProjctId", c => c.Guid(nullable: false));
            DropColumn("dbo.Tasks", "ProjectId");
        }
    }
}
