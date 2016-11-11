namespace ReadAndWatchList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReadingList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReadingListRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReadingListId = c.Int(nullable: false),
                        MovieAndBookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoviesAndBooks", t => t.MovieAndBookId, cascadeDelete: true)
                .ForeignKey("dbo.ReadingLists", t => t.ReadingListId, cascadeDelete: true)
                .Index(t => t.ReadingListId)
                .Index(t => t.MovieAndBookId);
            
            CreateTable(
                "dbo.ReadingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReadingListRows", "ReadingListId", "dbo.ReadingLists");
            DropForeignKey("dbo.ReadingListRows", "MovieAndBookId", "dbo.MoviesAndBooks");
            DropIndex("dbo.ReadingListRows", new[] { "MovieAndBookId" });
            DropIndex("dbo.ReadingListRows", new[] { "ReadingListId" });
            DropTable("dbo.ReadingLists");
            DropTable("dbo.ReadingListRows");
        }
    }
}
