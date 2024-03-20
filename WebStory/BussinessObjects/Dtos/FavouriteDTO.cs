using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObjects.Dtos
{
    public class FavouriteDTO
    {
        public int UserId { get; set; }

        public UserDTO UserDTO { get; set; }

        public int StoryId { get; set; }

        public StoryDTO StoryDTO { get; set; }
    }
}
