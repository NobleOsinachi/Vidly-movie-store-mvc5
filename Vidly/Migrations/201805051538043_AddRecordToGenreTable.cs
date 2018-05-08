namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecordToGenreTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "GenreName", c => c.String(nullable: false));

            Sql("INSERT INTO Genres (GenreName) VALUES ('Action')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Family')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (GenreName) VALUES ('Romance')");


        }

        public override void Down()
        {
            AlterColumn("dbo.Genres", "GenreName", c => c.Int(nullable: false));
        }
    }
}
