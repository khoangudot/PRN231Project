using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Models;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers;

public class HomeController : Controller
{
    private readonly IStoryService _storyService;
    private readonly ICategoryService _categoryService;
    private readonly IFavouriteService _favouriteService;

    public HomeController(IStoryService storyService,ICategoryService categoryService, IFavouriteService favouriteService)
    {
        _storyService = storyService;
        _categoryService = categoryService;
        _favouriteService = favouriteService;
    }

    public async Task<IActionResult> Index()
    {
        var responseC = await _categoryService.GetAllCategoriesAsync<ResponseDto>("");
        var response4 = await _storyService.GetTop4TrendingAsync<ResponseDto>("");
        DateTime filterDay = DateTime.Now.AddDays(-1);
        DateTime filterWeek = DateTime.Now.AddDays(-7);
        DateTime filterMonth = DateTime.Now.AddDays(-30);
        DateTime filterYear = DateTime.Now.AddDays(-365);
        var a = filterYear.ToString("yyyy-MM-dd HH:mm:ss");
        var responseTopViewDay = await _storyService.GetTopViewAsync<ResponseDto>(filterDay, "");
        var responseTopViewWeek = await _storyService.GetTopViewAsync<ResponseDto>(filterWeek, "");
        var responseTopViewMonth = await _storyService.GetTopViewAsync<ResponseDto>(filterMonth, "");
        var responseTopViewYear = await _storyService.GetTopViewAsync<ResponseDto>(filterYear, "");
        var response10 = await _storyService.GetTop10PopularAsync<ResponseDto>("");

        var token = HttpContext.Session.GetString("token");
        if (token != null)
        {
            var uid = CheckService.GetUserId(token);
            var f = await _favouriteService.GetAllAsync<ResponseDto>(token, uid);
            var rf = JsonConvert.DeserializeObject<IEnumerable<FavouriteDTO>>(Convert.ToString(f.Result));
            ViewBag.Favourites = rf;
            ViewBag.Uid = uid;
        }

        var checkRespose = responseC.IsSuccess && response4.IsSuccess && response10.IsSuccess && responseTopViewDay.IsSuccess && responseTopViewWeek.IsSuccess && responseTopViewMonth.IsSuccess && responseTopViewYear.IsSuccess;
        if (checkRespose)
        {
            var top4 = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(response4.Result));
            var topViewDay = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(responseTopViewDay.Result));
            var topViewWeek = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(responseTopViewWeek.Result));
            var topViewMonth = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(responseTopViewMonth.Result));
            var topViewYear = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(responseTopViewYear.Result));
            var top10 = JsonConvert.DeserializeObject<IEnumerable<StoryDTO>>(Convert.ToString(response10.Result));
            var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(Convert.ToString(responseC.Result));
            ViewBag.Categories = categories;
            ViewBag.Top4 = top4;
            ViewBag.TopViewDay = topViewDay;
            ViewBag.TopViewWeek = topViewWeek;
            ViewBag.TopViewMonth = topViewMonth;
            ViewBag.TopViewYear = topViewYear;
            ViewBag.Top10 = top10;
            return View("Views/Home/Index.cshtml");
        }
        return View("Views/Shared/Error.cshtml");
    }
}

