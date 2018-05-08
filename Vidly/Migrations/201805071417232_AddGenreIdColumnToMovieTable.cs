namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdColumnToMovieTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            RenameColumn(table: "dbo.Movies", name: "genre_Id", newName: "GenreId");
            AlterColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            AlterColumn("dbo.Movies", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "genre_Id");
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
    }
}
