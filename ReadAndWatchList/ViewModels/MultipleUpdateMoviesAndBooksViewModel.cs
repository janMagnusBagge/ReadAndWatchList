using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.ViewModels
{
    public class MultipleUpdateMoviesAndBooksViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Grade")]
        public int? GradeId { get; set; }
        [Display(Name = "Grade")]
        public string Grade { get; set; }
        [Display(Name = "Serie")]
        public int? SerieId { get; set; }
        [Display(Name = "Serie")]
        public string SerieName { get; set; }
        [Display(Name = "Main Category")]
        public int? MainCategoryId { get; set; }
        [Display(Name = "Main Category")]
        public string MainCategoryName { get; set; }
        [Display(Name = "Sub Category")]
        public int? SubCategoriId { get; set; }
        [Display(Name = "Sub Category")]
        public string SubCategoryName { get; set; }
        [Display(Name = "Update Movie/Book")]
        public bool UpdateThis { get; set; }
    }
}