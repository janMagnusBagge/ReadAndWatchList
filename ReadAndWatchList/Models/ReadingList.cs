using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Models
{
    public class ReadingList
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Reading listname")]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReadingListRow> ReadingListRow { get; set; }
    }
}