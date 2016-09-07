using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReadAndWatchList.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Serie")]
        public string SerieName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MoviesAndBooks> MoviesAndBooks { get; set; }
    }
}