namespace ReadAndWatchList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetweenSubMainCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MoviesAndBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        OtherPlatforms = c.String(),
                        Similar = c.Int(nullable: false),
                        GradeId = c.Int(),
                        PartOffSerie = c.Boolean(nullable: false),
                        WhatSerieName = c.String(),
                        SerieId = c.Int(),
                        MainCategoryId = c.Int(),
                        SubCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .ForeignKey("dbo.Categories", t => t.MainCategoryId)
                .ForeignKey("dbo.Series", t => t.SerieId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .Index(t => t.GradeId)
                .Index(t => t.SerieId)
                .Index(t => t.MainCategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerieName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Similars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoiceOne = c.Int(nullable: false),
                        ChoiceTwo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BetweenSubMainCategories", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.BetweenSubMainCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.MoviesAndBooks", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.MoviesAndBooks", "SerieId", "dbo.Series");
            DropForeignKey("dbo.MoviesAndBooks", "MainCategoryId", "dbo.Categories");
            DropForeignKey("dbo.MoviesAndBooks", "GradeId", "dbo.Grades");
            DropIndex("dbo.MoviesAndBooks", new[] { "SubCategoryId" });
            DropIndex("dbo.MoviesAndBooks", new[] { "MainCategoryId" });
            DropIndex("dbo.MoviesAndBooks", new[] { "SerieId" });
            DropIndex("dbo.MoviesAndBooks", new[] { "GradeId" });
            DropIndex("dbo.BetweenSubMainCategories", new[] { "SubCategoryId" });
            DropIndex("dbo.BetweenSubMainCategories", new[] { "CategoryId" });
            DropTable("dbo.Similars");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Series");
            DropTable("dbo.Grades");
            DropTable("dbo.MoviesAndBooks");
            DropTable("dbo.Categories");
            DropTable("dbo.BetweenSubMainCategories");
        }
    }
}
