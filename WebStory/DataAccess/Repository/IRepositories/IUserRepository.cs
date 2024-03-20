using BussinessObjects.Dtos;

namespace DataAccess.Repository.Irepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> GetUserByEmailAndPassword(string email, string password);
        Task<UserDTO> GetUserByEmail(string email);
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
        Task<UserDTO> UpdatePassword(UserDTO userDTO);
        Task<bool> CheckDuplicate(string email, string username);
        Task<bool> DeleteUser(int userId);


    }
}
