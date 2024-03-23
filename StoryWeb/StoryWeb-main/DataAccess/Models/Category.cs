using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace StoryAPI.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }

		public string CategoryName { get; set; }

		public virtual ICollection<StoryCategory> StoryCategories { get; set; }
    }
}

