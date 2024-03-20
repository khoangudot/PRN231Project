using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
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
