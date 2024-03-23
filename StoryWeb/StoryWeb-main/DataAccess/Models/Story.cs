	using System;
using System.ComponentModel.DataAnnotations;
using DataAccess.Models;

namespace StoryAPI.Models
{
	public class Story
	{
		[Key]
		public int StoryId { get; set; }

		public string Title { get; set; }

		public string AuthorName { get; set; }

		public string Content { get; set; }

		public int View { get; set; }

		public DateTime CreateAt { get; set; }

		public string ImageStory { get; set; }

		public bool IsActive { get; set; }

		public virtual ICollection<StoryCategory> StoryCategories { get; set; }

		public virtual ICollection<Chapter> Chapters { get; set; }
    }
}

