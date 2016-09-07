using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReadAndWatchList.Models
{
    public class Grades
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Grade")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MoviesAndBooks> MoviesAndBooks { get; set; }
    }
}