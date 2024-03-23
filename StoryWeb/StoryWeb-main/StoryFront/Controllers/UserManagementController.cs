using System;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers
{
	public class UserManagementController : Controller
	{
        private IUserService _userService;

		public UserManagementController(IUserService userService)
		{
            _userService = userService;
		}

        public async Task<IActionResult> UserIndex()
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            List<UserDTO> list = new();
            var response = await _userService.GetAllUsersAsync<ResponseDto>(token);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<UserDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> UserCreate()
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCreate(UserDTO userDto)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            ModelState.Remove(nameof(userDto.ImageUser));
            if (userDto.File == null)
            {
                ModelState.AddModelError(nameof(userDto.File), "File is required");
            }
            if (ModelState.IsValid)
            {
                userDto.ImageUser = await FirebaseService.CreateImage(userDto.File, "Users");
                userDto.File = null;
                var response = await _userService.CreateUserAsync<ResponseDto>(userDto, token);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(UserIndex));
                }
            }
            return View();
        }

        public async Task<IActionResult> UserEdit(int userId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            UserDTO model = new();
            var response = await _userService.GetUserByIdAsync<ResponseDto>(userId, token);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserEdit(UserDTO userDto)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            ModelState.Remove(nameof(userDto.Email));
            ModelState.Remove(nameof(userDto.Password));
            if (ModelState.IsValid)
            {
                if (userDto.File != null)
                {
                    await FirebaseService.EditImage(userDto.File, userDto.ImageUser, "Users");
                    userDto.File = null;
                }
                var response = await _userService.UpdateUserAsync<ResponseDto>(userDto, token);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(UserIndex));
                }
            }
            return View();
        }

        public async Task<IActionResult> UserDelete(int userId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            var response = await _userService.DeleteUserAsync<ResponseDto>(userId, token);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(UserIndex));
            }
            return RedirectToAction(nameof(UserIndex));
        }
    }
}

