using System;
using System.ComponentModel.DataAnnotations.Schema;
using StoryAPI.Models;

namespace DataAccess.Models
{
	public class StoryCategory
	{
		public int CategoryId { get; set; }
		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

		public int StoryId { get; set; }
		[ForeignKey("StoryId")]
		public virtual Story Story { get; set; }
	}
}

