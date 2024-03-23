using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Dtos
{
    public class ImageDTO
    {

        public int ImageId { get; set; }

        public int ChapterId { get; set; }

        public string ImageChapter { get; set; }

        public int Index { get; set; }
    }
}
