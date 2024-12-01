namespace ProjectManager_Main.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeofcomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Name");
        }
    }
}
