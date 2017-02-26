using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.ViewModels
{
    public class ReadingListViewModel
    {
        [Display(Name = "Movies and books")]
        public IList<ReadingListDetailViewModel> ReadingLists { get; set; } = new List<ReadingListDetailViewModel>();
        [Display(Name = "Movies and books")]
        public IList<ReadingListSelectMoviesAndBooksRowViewModel> ReadingListRowsForCreate { get; set; } = new List<ReadingListSelectMoviesAndBooksRowViewModel>();
    }
    public class ReadingListDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        
    }

    public class ReadingListSelectMoviesAndBooksRowViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Author")]
        public string AuthorName { get; set; }
        [Display(Name = "Category name")]
        public string CategoryName { get; set; }
        [Display(Name = "Serie name")]
        public string SerieName { get; set; }
    }
}