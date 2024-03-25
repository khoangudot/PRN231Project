using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers
{
	public class AuthController : Controller
	{
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public AuthController(IAuthService authService, IUserService userService, ICategoryService categoryService)
		{
            _authService = authService;
            _userService = userService;
            _categoryService = categoryService;
		}

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var responseC = await _categoryService.GetAllCategoriesAsync<ResponseDto>("");
            if (responseC.IsSuccess && responseC.Result != null)
            {
                var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(Convert.ToString(responseC.Result));
                ViewBag.Categories = categories;
                return View();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var response = await _authService.Login<ResponseDto>(email, password);
            if (response.IsSuccess && response.Result != null)
            {
                var token = Convert.ToString(response.Result);
                HttpContext.Session.SetString("token", token);
                return RedirectToAction("Index", "Home");
            }
            ViewData["Checked"] = "Your email or password are wrong!";
            return await Login();
        }

        public async Task<IActionResult> SignUp()
        {
            var responseC = await _categoryService.GetAllCategoriesAsync<ResponseDto>("");
            if (responseC.IsSuccess && responseC.Result != null)
            {
                var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(Convert.ToString(responseC.Result));
                ViewBag.Categories = categories;
                return View();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserDTO userDto)
        {
            ModelState.Remove(nameof(userDto.ImageUser));
            if (userDto.File == null)
            {
                ModelState.AddModelError(nameof(userDto.File), "File is required");
            }
            if (ModelState.IsValid)
            {
                userDto.ImageUser = await FirebaseService.CreateImage(userDto.File, "Users");
                userDto.File = null;
                var response = await _userService.CreateUserAsync<ResponseDto>(userDto, "");
                if (response != null && response.IsSuccess)
                {
                    var user = JsonConvert.DeserializeObject<UserDTO>(Convert.ToString(response.Result));
                    var responseL = await _authService.Login<ResponseDto>(user.Email, user.Password);
                    if (responseL.IsSuccess && responseL.Result != null)
                    {
                        var token = Convert.ToString(responseL.Result);
                        HttpContext.Session.SetString("token", token);
                        return RedirectToAction("Index", "Home");
                    }
                    return NotFound();
                }
            }
            var responseC = await _categoryService.GetAllCategoriesAsync<ResponseDto>("");
            if (responseC.IsSuccess && responseC.Result != null)
            {
                var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(Convert.ToString(responseC.Result));
                ViewBag.Categories = categories;
                return View();
            }
            return NotFound();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction(nameof(Login));
        }
    }
}

