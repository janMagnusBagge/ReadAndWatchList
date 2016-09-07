namespace ReadAndWatchList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using ReadAndWatchList.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ReadAndWatchList.DataAccessLayer.ReadAndWatchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ReadAndWatchList.DataAccessLayer.ReadAndWatchContext";
        }

        protected override void Seed(ReadAndWatchList.DataAccessLayer.ReadAndWatchContext context)
        {
			//context.Serie.AddOrUpdate(
			//	s => s.SerieName,
			//	new Series { SerieName = "Wheel of time", Description = "" },
			//	new Series { SerieName = "A Song of Ice and Fire", Description = "" },
			//	new Series { SerieName = "A throne of glass", Description = "" },
			//	new Series { SerieName = "The Sword of shannara", Description = "" },
			//	new Series { SerieName = "The Genesis of Shannara", Description = "" },
			//	new Series { SerieName = "Legends of Shannara", Description = "" },
			//	new Series { SerieName = "The Voyage of the Jerle Shannara", Description = "" },
			//	new Series { SerieName = "High Druid of Shannara", Description = "" },
			//	new Series { SerieName = "The Dresden files", Description = "" }
			//	);
			//context.SaveChanges();

			//context.Grade.AddOrUpdate(
			//	g => g.Name,
			//	new Grades { Name = "Bra", Description = "" },
			//	new Grades { Name = "Mycket bra", Description = "" },
			//	new Grades { Name = "Dålig", Description = "" },
			//	new Grades { Name = "Mycket dålig", Description = "" },
			//	new Grades { Name = "Godkännd", Description = "" }
			//	);
			//context.SaveChanges();

			//context.Categorie.AddOrUpdate(
			//	g => g.Name,
			//	new Categories { Name = "Film", Description = "" },
			//	new Categories { Name = "Serier", Description = "" },
			//	new Categories { Name = "Anime", Description = "" },
			//	new Categories { Name = "Böcker", Description = "" },
			//	new Categories { Name = "Godkännd", Description = "" }
			//	);
			//context.SaveChanges();

			//context.SubCategorie.AddOrUpdate(
			//	g => g.Name,
			//	new SubCategories { Name = "Fantasy", Description = "" },
			//	new SubCategories { Name = "Sci-Fy", Description = "" },
			//	new SubCategories { Name = "Deckare", Description = "" },
			//	new SubCategories { Name = "Ungdom", Description = "" },
			//	new SubCategories { Name = "Programmering", Description = "" }
			//	);
			//context.SaveChanges();

			//context.BetweenCategory.AddOrUpdate(
			//	g => g.CategoryId,
			//	new BetweenSubMainCategory { CategoryId = 1, SubCategoryId = 1 },
			//	new BetweenSubMainCategory { CategoryId = 1, SubCategoryId = 2 },
			//	new BetweenSubMainCategory { CategoryId = 2, SubCategoryId = 1 },
			//	new BetweenSubMainCategory { CategoryId = 2, SubCategoryId = 2 },
			//	new BetweenSubMainCategory { CategoryId = 3, SubCategoryId = 1 },
			//	new BetweenSubMainCategory { CategoryId = 3, SubCategoryId = 2 }
			//	);
			//context.SaveChanges();

			////context.Similar.AddOrUpdate(
			////    g => g.ChoiceOne,
			////    new Similar { ChoiceOne = 0, ChoiceTwo = 0 }
			////    );
			////context.SaveChanges();

			//context.MovieAndBook.AddOrUpdate(
			//	g => g.Name,
			//	new MoviesAndBooks { Name = "The Sword of shannara", Description = "", OtherPlatforms = "", Similar = 0, GradeId = 1, PartOffSerie = true, WhatSerieName = "", SerieId = 4, MainCategoryId = 4, SubCategoryId = 1 },
			//	new MoviesAndBooks { Name = "Summer knight", Description = "", OtherPlatforms = "", Similar = 0, GradeId = 1, PartOffSerie = true, WhatSerieName = "", SerieId = 9, MainCategoryId = 4, SubCategoryId = 1 }
			//	);
        }
    }
}
