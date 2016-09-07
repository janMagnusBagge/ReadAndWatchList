using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndWatchList.Models
{
    public class SubCategories
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Sub Category")]
        public string Name { get; set; }
        public string Description { get; set; }

        //[Display(Name = "Sub Categorie off")]
        //[ForeignKey("Id")]
        //public int SubCategorieOff { get; set; }
        //public Categories Categorie { get; set; }

        //Till huvudkategori för att plocka underkategori
        public virtual ICollection<BetweenSubMainCategory> BetweenSubMainCategori { get; set; }

        //Till movies and books för att plocka underkategori
        public virtual ICollection<MoviesAndBooks> SubCategori { get; set; }
    }
}