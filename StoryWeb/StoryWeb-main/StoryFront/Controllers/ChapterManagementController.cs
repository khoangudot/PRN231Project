using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ObjectModel.Dtos;
using System.IO;
using Firebase.Storage;
using StoryFront.Services.IServices;
using Newtonsoft.Json;
using StoryFront.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StoryFront.Helpers;
using System.Collections;
using System.Reflection;

namespace StoryFront.Controllers
{
    public class ChapterManagementController : Controller
    {
        private IChapterService _chapterService;
        private IStoryService _storyService;

        public ChapterManagementController(IChapterService chapterService, IStoryService storyService)
        {
            _chapterService = chapterService;
            _storyService = storyService;
        }

        public async Task<IActionResult> ChapterIndex(int storyId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            List<ChapterDTO> list = new();
            var response = await _chapterService.GetChaptersByStoryIdAsync<ResponseDto>(storyId ,token);
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ChapterDTO>>(Convert.ToString(response.Result));
            } else
            {
                return NotFound();
            }
            return View(list);
        }

        public async Task<IActionResult> ChapterCreate(int storyId)
        {
            ChapterDTO model = new ChapterDTO();
            model.StoryId = storyId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChapterCreate(ChapterDTO model)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            var response = await _chapterService.GetChapterByIndexAsync<ResponseDto>(model.Index, model.StoryId, token);
            if (response.Result != null)
            {
                ModelState.AddModelError(nameof(model.Index), "That index is exist!");
            }
            if (model.ListOfFile == null)
            {
                ModelState.AddModelError(nameof(model.ListOfFile), "You need to add images");
            }
            if (response.Result != null || model.ListOfFile == null)
            {
                return View(model);
            }
            ModelState.Remove(nameof(model.ListOfImage));
            var storyDto = new StoryDTO();
            var responseGetStory = await _storyService.GetStoryByIdAsync<ResponseDto>(model.StoryId, token);
            if (responseGetStory != null && responseGetStory.IsSuccess)
            {
                storyDto = JsonConvert.DeserializeObject<StoryDTO>(Convert.ToString(responseGetStory.Result));
            } else
            {
                return NotFound();
            }
            var listOfImage = new List<ImageDTO>();
            for (int i = 0; i < model.ListOfFile.Count; i++)
            {
                var image = new ImageDTO
                {
                    Index = i + 1,
                    ImageChapter = await FirebaseService.CreateImage(model.ListOfFile[i], storyDto.Title.Replace(" ", ""), "es" + model.Index)
                };
                listOfImage.Add(image);
            }
            model.ListOfImage = listOfImage;
            model.ListOfFile = null;
            var responseCreateChapter = await _chapterService.CreateChapterAsync<ResponseDto>(model, token);
            if (responseCreateChapter != null && responseCreateChapter.IsSuccess)
            {
                return RedirectToAction(nameof(ChapterIndex), new { storyId = model.StoryId });
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> ChapterDelete(int chapterId, int storyId)
        {
            var token = HttpContext.Session.GetString("token");
            if (!CheckService.IsAdmin(token))
            {
                return NotFound();
            }
            var storyDto = new StoryDTO();
            var responseGetStory = await _storyService.GetStoryByIdAsync<ResponseDto>(storyId, token);
            if (responseGetStory != null && responseGetStory.IsSuccess)
            {
                storyDto = JsonConvert.DeserializeObject<StoryDTO>(Convert.ToString(responseGetStory.Result));
            }
            else
            {
                return NotFound();
            }
            var responseGetChapter = await _chapterService.GetChapterByIdAsync<ResponseDto>(chapterId, token);
            if (responseGetChapter != null && responseGetChapter.IsSuccess)
            {
                var chapterDto = JsonConvert.DeserializeObject<ChapterDTO>(Convert.ToString(responseGetChapter.Result));
                foreach (var image in chapterDto.ListOfImage)
                {
                    await FirebaseService.DeleteImage(image.ImageChapter, storyDto.Title.Replace(" ", ""), "es" + chapterDto.Index);
                }
            }
            else
            {
                return NotFound();  
            }
            var response = await _chapterService.DeleteChapterAsync<ResponseDto>(chapterId, token);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ChapterIndex), new { storyId = storyId });
            } else
            {
                return NotFound();
            }
        }
    }
}

