using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectModel.Dtos
{
    public class AddFavouriteDTO
    {
        public int UserId { get; set; }

        public int StoryId { get; set; }
    }
}
