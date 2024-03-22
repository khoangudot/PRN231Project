using BussinessObjects.Dtos;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepositories
{
    public interface IFavouriteRepository
    {
        Task<IEnumerable<FavouriteDTO>> GetFavourites(int userId);

        Task<Favourite> GetFavourite(int userId, int storyId);

        Task<bool> AddFavourite(AddFavouriteDTO favourite);

        Task<bool> RemoveFavourite(AddFavouriteDTO favourite);
    }
}
