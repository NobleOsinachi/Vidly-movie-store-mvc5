namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecordInMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Pay as You Go' WHERE Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE Id=3");

        }

        public override void Down()
        {
        }
    }
}
