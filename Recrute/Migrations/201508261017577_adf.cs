namespace Recrute.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "typeID", "dbo.TypeUsers");
            DropIndex("dbo.User", new[] { "typeID" });
            AlterColumn("dbo.User", "phoneNum", c => c.String());
            AlterColumn("dbo.User", "gsmNum", c => c.String());
            DropColumn("dbo.User", "typeID");
            DropTable("dbo.TypeUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypeUsers",
                c => new
                    {
                        typeID = c.Int(nullable: false, identity: true),
                        typeLabel = c.String(),
                    })
                .PrimaryKey(t => t.typeID);
            
            AddColumn("dbo.User", "typeID", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "gsmNum", c => c.Int());
            AlterColumn("dbo.User", "phoneNum", c => c.Int());
            CreateIndex("dbo.User", "typeID");
            AddForeignKey("dbo.User", "typeID", "dbo.TypeUsers", "typeID", cascadeDelete: true);
        }
    }
}
