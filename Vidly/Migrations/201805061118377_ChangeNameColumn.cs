namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            RenameColumn(table: "dbo.Customers", name: "MembershipType_Id", newName: "MemebershipTypeId");
            AlterColumn("dbo.Customers", "MemebershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MemebershipTypeId");
            AddForeignKey("dbo.Customers", "MemebershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MemebershipType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MemebershipType_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customers", "MemebershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemebershipTypeId" });
            AlterColumn("dbo.Customers", "MemebershipTypeId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "MemebershipTypeId", newName: "MembershipType_Id");
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
