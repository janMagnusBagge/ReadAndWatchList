using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndWatchList.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Main Category")]
        public string Name { get; set; }
        public string Description { get; set; }

        //Till underkategori för att plocka kategori
        //public ICollection<SubCategories> SubCategori { get; set; }
        public virtual ICollection<BetweenSubMainCategory> BetweenCategori { get; set; }

        //Till movies and books för att plocka kategori
        public virtual ICollection<MoviesAndBooks> MainCategori { get; set; }
    }
}