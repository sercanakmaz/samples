namespace AspNetBuilerplate.Sample1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskMig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        State = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppTasks");
        }
    }
}
