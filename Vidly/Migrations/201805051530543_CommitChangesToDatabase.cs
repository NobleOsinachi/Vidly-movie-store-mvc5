namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommitChangesToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "genre_Id");
            AddForeignKey("dbo.Movies", "genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "genre_Id" });
            DropColumn("dbo.Movies", "genre_Id");
            DropTable("dbo.Genres");
        }
    }
}
