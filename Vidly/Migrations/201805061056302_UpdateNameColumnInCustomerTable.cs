namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameColumnInCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MemebershipType_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MemebershipType_Id");
        }
    }
}
