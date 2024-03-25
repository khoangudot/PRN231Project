using DataAccess.Repositories.IRepositories;
using Firebase.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjectModel.Dtos;

namespace StoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._response = new ResponseDto();
        }
        [HttpGet]
        [Authorize(Roles = "1")]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<UserDTO> userDtos = await _userRepository.GetUsers();
                _response.Result = userDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<object> Get(int id)
        {
            try
            {
                UserDTO userDto = await _userRepository.GetUserById(id);
                _response.Result = userDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Post([FromBody] UserDTO userDto)
        {
            try
            {
                if (await _userRepository.GetUserById(userDto.UserId) == null)
                {
                    if (await _userRepository.GetUserByEmail(userDto.Email) == null)
                    {
                        UserDTO model = await _userRepository.CreateUser(userDto);
                        _response.Result = model;
                    } else
                    {
                        throw new Exception("This user email is exist");
                    }
                } else
                {
                    throw new Exception("This user is exist");
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
        [Authorize]
        public async Task<object> Put([FromBody] UserDTO userDto)
        {
            try
            {
                if (await _userRepository.GetUserById(userDto.UserId) != null)
                {
                    UserDTO model = await _userRepository.UpdateUser(userDto);
                    _response.Result = model;
                }
                else
                {
                    throw new Exception("This user is NOT exist");
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("ChangePassword")]
        [Authorize]
        public async Task<object> ChangePassword([FromBody] UserDTO userDto)
        {
            try
            {
                if (await _userRepository.GetUserById(userDto.UserId) != null)
                {
                    UserDTO model = await _userRepository.UpdatePassword(userDto);
                    _response.Result = model;
                }
                else
                {
                    throw new Exception("This user is NOT exist");
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "1")]
        public async Task<object> Delete(int id)
        {
            try
            {
                if (await _userRepository.GetUserById(id) != null)
                {
                    bool isSuccess = await _userRepository.DeleteUser(id);
                    _response.Result = isSuccess;
                    if (!isSuccess)
                    {
                        throw new Exception("Can't delete");
                    }
                }
                else
                {
                    throw new Exception("This user is NOT exist");
                }
                
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
