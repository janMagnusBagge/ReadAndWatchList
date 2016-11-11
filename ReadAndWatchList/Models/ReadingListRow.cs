using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.Models
{
    public class ReadingListRow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ReadingList")]
        public int ReadingListId { get; set; }
        public virtual ReadingList ReadingList { get; set; }

        [ForeignKey("MoviesAndBooks")]
        public int MovieAndBookId { get; set; }
        public virtual MoviesAndBooks MoviesAndBooks { get; set; }

    }
}