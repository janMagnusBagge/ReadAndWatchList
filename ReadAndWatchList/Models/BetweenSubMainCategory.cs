using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadAndWatchList.Models
{
    public class BetweenSubMainCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Main Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }

        [Display(Name = "Sub Category")]
        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public virtual SubCategories SubCategory { get; set; }

    }
}