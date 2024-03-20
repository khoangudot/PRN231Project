using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Dtos
{
    public class AddCommentDTO
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }


        public int StoryId { get; set; }

        public int? ParentCommentId { get; set; }

        public int Index { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
