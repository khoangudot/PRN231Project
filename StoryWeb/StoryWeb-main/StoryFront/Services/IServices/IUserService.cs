using System;
using ObjectModel.Dtos;

namespace StoryFront.Services.IServices
{
	public interface IUserService
	{
        Task<T> GetAllUsersAsync<T>(string token);
        Task<T> GetUserByIdAsync<T>(int id, string token);
        Task<T> CreateUserAsync<T>(UserDTO userDto, string token);
        Task<T> UpdateUserAsync<T>(UserDTO userDto, string token);
        Task<T> UpdatePasswordAsync<T>(UserDTO userDto, string token);
        Task<T> DeleteUserAsync<T>(int id, string token);
    }
}

