using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
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
