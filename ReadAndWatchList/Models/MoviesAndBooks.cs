using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndWatchList.Models
{
    public class MoviesAndBooks
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OtherPlatforms { get; set; }
        public int Similar { get; set; }

        [Display(Name = "Grade")]
        [ForeignKey("Grade")]
        public int? GradeId { get; set; }
        [Display(Name = "Grade")]
        public virtual Grades Grade { get; set; }

        [Display(Name = "Part Of Serie")]
        public bool PartOffSerie { get; set; }
        public string WhatSerieName { get; set; }

        [Display(Name = "Serie")]
        [ForeignKey("Series")]
        public int? SerieId { get; set; }
        [Display(Name = "Serie")]
        public virtual Series Series { get; set; }

        [Display(Name = "Main Category")]
        [ForeignKey("MainCategorie")]
        public int? MainCategoryId { get; set; }
        [Display(Name = "Main Category")]
        public virtual Categories MainCategorie { get; set; }

        [Display(Name = "Sub Category")]
        [ForeignKey("SubCategori")] //vilken som ska vara att spara underkategori i
        public int? SubCategoryId { get; set; }
        [Display(Name = "Sub Category")]
        public virtual SubCategories SubCategori { get; set; }


        public virtual ICollection<ReadingListRow> ReadingListRow { get; set; }
    }
}