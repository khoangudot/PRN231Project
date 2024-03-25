using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryAPI.Models
{
	public class Favourite
	{
		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		public int StoryId { get; set; }
		[ForeignKey("StoryId")]
		public virtual Story Story { get; set; }
	}
}

