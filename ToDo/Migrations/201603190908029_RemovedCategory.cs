namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "Category_Id" });
            AddColumn("dbo.Tasks", "IsDone", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tasks", "Category_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tasks", "Category_Id", c => c.Int());
            DropColumn("dbo.Tasks", "IsDone");
            CreateIndex("dbo.Tasks", "Category_Id");
            AddForeignKey("dbo.Tasks", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
