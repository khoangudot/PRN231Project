using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers
{
    public class MangaManagementController : Controller
    {
        private IStoryService _storyService;
        private ICategoryService _categoryService;

        public MangaManagementController(IStoryService storyService, ICategoryService categoryService)
        {
            _storyService = storyService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> MangaIndex()
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            List<StoryDTO> list = new();
            var response = await _storyService.GetAllStorysAsync<ResponseDto>(token);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<StoryDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                return NotFound();
            }
            return View(list);
        }

        public async Task<IActionResult> MangaCreate()
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            List<CategoryDTO> listCategory = new();
            var response = await _categoryService.GetAllCategoriesAsync<ResponseDto>(token);
            if (response != null && response.IsSuccess)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                return NotFound();
            }
            ViewData["listCategory"] = listCategory;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MangaCreate(StoryDTO storyDto)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            for (int i = 0; i < storyDto.ListOfChapter.Count; i++)
            {
                string listOfImage = "ListOfChapter[" + i + "].ListOfImage";
                ModelState.Remove(listOfImage);
            }
            ModelState.Remove(nameof(storyDto.ImageStory));
            if (storyDto.FileHeader == null)
            {
                ModelState.AddModelError(nameof(storyDto.FileHeader), "File is required");
            }
            if (ModelState.IsValid)
            {
                //var token = HttpContext.Session.GetString("token");
                //if (token == null)
                //{
                //    return NotFound();
                //}
                List<CategoryDTO> listCategory = new();
                var responseGetCategory = await _categoryService.GetAllCategoriesAsync<ResponseDto>(token);
                if (responseGetCategory != null && responseGetCategory.IsSuccess)
                {
                    listCategory = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(responseGetCategory.Result));
                }
                else
                {
                    return NotFound();
                }
                var listCategoryDto = new List<CategoryDTO>();
                var listIndexCategory = Enumerable.Range(0, storyDto.ListOfCheckedCategory.Count).Where(i => storyDto.ListOfCheckedCategory[i]).ToList();
                for (int i = 0; i < listCategory.Count; i++)
                {
                    if (listIndexCategory.Any(x => x == i))
                    {
                        var cate = new CategoryDTO
                        {
                            CategoryId = listCategory[i].CategoryId
                        };
                        listCategoryDto.Add(cate);
                    }
                }
                storyDto.ListOfCategory = listCategoryDto;
                storyDto.ImageStory = await FirebaseService.CreateImage(storyDto.FileHeader, storyDto.Title.Replace(" ", ""));
                storyDto.FileHeader = null;
                if (storyDto.ListOfChapter.Count > 0)
                {
                    for (int i = 0; i < storyDto.ListOfChapter.Count; i++)
                    {
                        var listOfImage = new List<ImageDTO>();
                        for (int j = 0; j < storyDto.ListOfChapter[i].ListOfFile.Count; j++)
                        {
                            var image = new ImageDTO
                            {
                                Index = j + 1,
                                ImageChapter = await FirebaseService.CreateImage(storyDto.ListOfChapter[i].ListOfFile[j], storyDto.Title.Replace(" ", ""), "es" + (i + 1))
                            };
                            listOfImage.Add(image);
                        }
                        storyDto.ListOfChapter[i].Index = i + 1;
                        storyDto.ListOfChapter[i].ListOfImage = listOfImage;
                        storyDto.ListOfChapter[i].ListOfFile = null;
                    }
                }
                var response = await _storyService.CreateStoryAsync<ResponseDto>(storyDto, token);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(MangaIndex));
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }

        public async Task<IActionResult> MangaEdit(int storyId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            List<CategoryDTO> listCategory = new();
            var response = await _categoryService.GetAllCategoriesAsync<ResponseDto>(token);
            if (response != null && response.IsSuccess)
            {
                listCategory = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result));
            }
            else
            {
                return NotFound();
            }
            ViewData["listCategory"] = listCategory;
            StoryDTO model = new();
            response = await _storyService.GetStoryByIdAsync<ResponseDto>(storyId, token);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<StoryDTO>(Convert.ToString(response.Result));
                var listCheckedCategory = new List<bool>();
                for (int i = 0; i < listCategory.Count; i++)
                {
                    if (model.ListOfCategory.Any(x => x.CategoryId == listCategory[i].CategoryId))
                    {
                        listCheckedCategory.Add(true);
                    }
                    else
                    {
                        listCheckedCategory.Add(false);
                    }
                }
                model.ListOfCheckedCategory = listCheckedCategory;
            }
            else
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MangaEdit(StoryDTO storyDto)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                List<CategoryDTO> listCategory = new();
                var responseGetCategory = await _categoryService.GetAllCategoriesAsync<ResponseDto>(token);
                if (responseGetCategory != null && responseGetCategory.IsSuccess)
                {
                    listCategory = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(responseGetCategory.Result));
                }
                else
                {
                    return NotFound();
                }
                var listCategoryDto = new List<CategoryDTO>();
                var listIndexCategory = Enumerable.Range(0, storyDto.ListOfCheckedCategory.Count).Where(i => storyDto.ListOfCheckedCategory[i]).ToList();
                for (int i = 0; i < listCategory.Count; i++)
                {
                    if (listIndexCategory.Any(x => x == i))
                    {
                        var cate = new CategoryDTO
                        {
                            CategoryId = listCategory[i].CategoryId
                        };
                        listCategoryDto.Add(cate);
                    }
                }
                storyDto.ListOfCategory = listCategoryDto;
                if (storyDto.FileHeader != null)
                {
                    await FirebaseService.EditImage(storyDto.FileHeader, storyDto.ImageStory, storyDto.Title.Replace(" ", ""));
                    storyDto.FileHeader = null;
                }
                var responseUpdateStory = await _storyService.UpdateStoryAsync<ResponseDto>(storyDto, token);
                if (responseUpdateStory != null && responseUpdateStory.IsSuccess)
                {
                    return RedirectToAction(nameof(MangaIndex));
                }
                else
                {
                    return NotFound();
                }
            }
            return View();
        }

        public async Task<IActionResult> MangaDelete(int storyId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            var responseDeleteStory = await _storyService.DeleteStoryAsync<ResponseDto>(storyId, token);
            if (responseDeleteStory != null && responseDeleteStory.IsSuccess)
            {
                return RedirectToAction(nameof(MangaIndex));
            }
            else
            {
                return NotFound();
            }
        }
    }
}

