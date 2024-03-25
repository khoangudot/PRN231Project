using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ObjectModel.Dtos
{
    public class StoryDTO
    {
		public int StoryId { get; set; }

		public string Title { get; set; }

		public string AuthorName { get; set; }

		public string Content { get; set; }

		public int View { get; set; }

		public DateTime CreateAt { get; set; }

		public string ImageStory { get; set; }

		public IFormFile? FileHeader { get; set; }

		public bool IsActive { get; set; }

		public List<CategoryDTO>? ListOfCategory { get; set; }

		public List<bool>? ListOfCheckedCategory { get; set; }

        public List<ChapterDTO>? ListOfChapter { get; set; }
    }
}
