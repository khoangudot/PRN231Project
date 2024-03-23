using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers
{
    public class FavouriteController : Controller
    {
        private IFavouriteService _favouriteService;
        private ICategoryService _categoryService;

        public FavouriteController(IFavouriteService favouriteService, ICategoryService categoryService)
        {
            _favouriteService = favouriteService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> AddFavourite(AddFavouriteDTO add)
        {
            var token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                return RedirectToAction("Login", "Auth", new { Value = "" });
            }
            add.UserId = CheckService.GetUserId(token);
            var response = await _favouriteService.AddFavouriteAsync<ResponseDto>(token, add);
            if (response.IsSuccess)
            {
                return Ok(new { success = true });
            }

            return BadRequest();
        }

        public async Task<IActionResult> DeleteFavourite(AddFavouriteDTO delete)
        {
            var token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                return RedirectToAction("Login", "Auth", new { Value = "" });
            }
            delete.UserId = CheckService.GetUserId(token);
            var response = await _favouriteService.DeleteFavouriteAsync<ResponseDto>(token, delete);
            if (response.IsSuccess)
            {
                return Ok(new { success = true });
            }

            return BadRequest();
        }

        public async Task<IActionResult> GetFavourites()
        {
            var token = HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                var userId = CheckService.GetUserId(token);
                var responseF = await _favouriteService.GetAllAsync<ResponseDto>(token, userId);
                var responseC = await _categoryService.GetAllCategoriesAsync<ResponseDto>("");
                if (responseF.IsSuccess && responseC.IsSuccess)
                {
                    var result = JsonConvert.DeserializeObject<IEnumerable<FavouriteDTO>>(Convert.ToString(responseF.Result));
                    var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(Convert.ToString(responseC.Result));
                    ViewBag.Favourites = result;
                    ViewBag.Categories = categories;
                    ViewBag.Uid = userId;
                    return View("Views/User/FavouriteList.cshtml");
                }
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
