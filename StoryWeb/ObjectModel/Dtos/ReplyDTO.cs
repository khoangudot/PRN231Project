using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Dtos
{
    public class ReplyDTO
    {
        public int CommentId { get; set; }

        public string? UserName { get; set; }

        public string? Image { get; set; }

        public int StoryId { get; set; }

        public int? ParentCommentId { get; set; }

        public int Index { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
