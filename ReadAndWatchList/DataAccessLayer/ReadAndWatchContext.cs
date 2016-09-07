using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ReadAndWatchList.Models;

namespace ReadAndWatchList.DataAccessLayer
{
    public class ReadAndWatchContext : DbContext
    {
        public ReadAndWatchContext() : base("DefaultConnection")
        {

        }

        public DbSet<Models.Categories> Categorie { get; set; }
        public DbSet<Models.SubCategories> SubCategorie { get; set; }
        public DbSet<Models.Grades> Grade { get; set; }
        public DbSet<Models.MoviesAndBooks> MovieAndBook { get; set; }
        public DbSet<Models.Series> Serie { get; set; }
        public DbSet<Models.Similar> Similar { get; set; }
        public DbSet<Models.BetweenSubMainCategory> BetweenCategory { get; set; }

        //public System.Data.Entity.DbSet<ReadAndWatchList.ViewModels.MultipleUpdateMoviesAndBooksViewModel> MultipleUpdateMoviesAndBooksViewModels { get; set; }
    }
}