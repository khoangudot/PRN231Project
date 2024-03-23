using System;
using ObjectModel.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repositories.IRepositories
{
	public interface IUserRepository
	{
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> GetUserByEmailAndPassword(string email, string password);
        Task<UserDTO> GetUserByEmail(string email);
        Task<UserDTO> CreateUser(UserDTO userDto);
        Task<UserDTO> UpdateUser(UserDTO userDto);
        Task<UserDTO> UpdatePassword(UserDTO userDto);
        Task<bool> CheckDuplicate(string email, string userName);
        Task<bool> DeleteUser(int userId);
    }
}

