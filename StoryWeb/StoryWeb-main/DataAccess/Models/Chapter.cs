using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryAPI.Models
{
	public class Chapter
	{
		[Key]
		public int ChapterId { get; set; }

		public int View { get; set; }

		public int Index { get; set; }

        public DateTime CreateAt { get; set; }

        public int StoryId { get; set; }
        [ForeignKey("StoryId")]
        public virtual Story Story { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}

