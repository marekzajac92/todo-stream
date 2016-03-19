namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "Deadline");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Deadline", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "Date");
        }
    }
}
