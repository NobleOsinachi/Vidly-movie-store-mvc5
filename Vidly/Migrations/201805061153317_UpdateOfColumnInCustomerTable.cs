namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOfColumnInCustomerTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "MemebershipTypeId", newName: "MembershipTypeId");
            RenameIndex(table: "dbo.Customers", name: "IX_MemebershipTypeId", newName: "IX_MembershipTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Customers", name: "IX_MembershipTypeId", newName: "IX_MemebershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "MemebershipTypeId");
        }
    }
}
