namespace AspNetBuilerplate.Sample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AppTasks", newName: "Tasks");
            DropPrimaryKey("dbo.Tasks");
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tasks", "AssignedPersonId", c => c.Int());
            AlterColumn("dbo.Tasks", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tasks", "Id");
            CreateIndex("dbo.Tasks", "AssignedPersonId");
            AddForeignKey("dbo.Tasks", "AssignedPersonId", "dbo.People", "Id");
            DropColumn("dbo.Tasks", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Title", c => c.String(nullable: false, maxLength: 256));
            DropForeignKey("dbo.Tasks", "AssignedPersonId", "dbo.People");
            DropIndex("dbo.Tasks", new[] { "AssignedPersonId" });
            DropPrimaryKey("dbo.Tasks");
            AlterColumn("dbo.Tasks", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Tasks", "AssignedPersonId");
            DropTable("dbo.People");
            AddPrimaryKey("dbo.Tasks", "Id");
            RenameTable(name: "dbo.Tasks", newName: "AppTasks");
        }
    }
}
