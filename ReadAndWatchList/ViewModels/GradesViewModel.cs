using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ReadAndWatchList.Models;

namespace ReadAndWatchList.ViewModels
{
    public class GradesViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Grade")]
        public string Name { get; set; }
        public string Description { get; set; }

        public GradesViewModel(Grades grade)
        {
            Id = grade.Id;
            Name = grade.Name;
            Description = grade.Description;
        }
    }
}