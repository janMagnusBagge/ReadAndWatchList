using ReadAndWatchList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadAndWatchList.ViewModels
{
	public class MoviesAndBooksViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string OtherPlatforms { get; set; }
		public int Similar { get; set; }
		public bool PartOffSerie { get; set; }
		public string WhatSerieName { get; set; }


		[Display(Name = "Grade")]
		public List<Grades> Grade { get; set; }

		[Display(Name = "Serie")]
		public List<Series> Series { get; set; }

		[Display(Name = "Main Category")]
		public List<Categories> MainCategory { get; set; }

		[Display(Name = "Sub Category")]
		public List<SubCategories> SubCategory { get; set; }
	}
}