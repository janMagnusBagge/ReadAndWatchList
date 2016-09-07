using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ReadAndWatchList.Models
{
    public class Similar
    {
        [Key]
        public int Id { get; set; }
        public int ChoiceOne { get; set; }
        public int ChoiceTwo { get; set; }
    }
}