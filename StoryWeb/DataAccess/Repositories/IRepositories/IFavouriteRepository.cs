using ObjectModel.Dtos;
using StoryAPI.Models;

namespace DataAccess.Repositories.IRepositories
{
    public interface IFavouriteRepository
    {
        Task<IEnumerable<FavouriteDTO>> GetFavourites(int userId);

        Task<Favourite> GetFavourite(int userId, int storyId);

        Task<bool> AddFavourite(AddFavouriteDTO favourite);

        Task<bool> RemoveFavourite(AddFavouriteDTO favourite);
    }
}
