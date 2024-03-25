using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoryAPI.Models
{
	public class Image
	{
        [Key]
        public int ImageId { get; set; }

        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        public string ImageChapter { get; set; }

        public int Index { get; set; }
    }
}

