using BussinessObjects.Dtos;
using DataAccess.Repository.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        protected ResponseDto _response;
        private IChapterRepository _chapterRepository;

        public ChapterController(IChapterRepository chapterRepository)
        {
            _chapterRepository = chapterRepository;
            this._response = new ResponseDto();
        }

        [HttpGet("GetChapterById/{id}")]
        [AllowAnonymous]
        public async Task<object> GetChapterById(int id)
        {
            try
            {
                ChapterDTO chapterDto = await _chapterRepository.GetChapterById(id);
                _response.Result = chapterDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("GetChaptersByStoryId/{storyId}")]
        [AllowAnonymous]
        public async Task<object> GetByStoryId(int storyId)
        {
            try
            {
                IEnumerable<ChapterDTO> chapterDtos = await _chapterRepository.GetChapterByStoryId(storyId);
                _response.Result = chapterDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("GetChapterByIndex/{storyId}/index/{index}")]
        [AllowAnonymous]
        public async Task<object> GetChapterByIndex(int index, int storyId)
        {
            try
            {
                ChapterDTO chapterDto = await _chapterRepository.GetChapterByIndex(index, storyId);
                _response.Result = chapterDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("CreateChapter")]
        [Authorize(Roles = "1")]
        public async Task<object> CreateChapter([FromBody] ChapterDTO chapterDto)
        {
            try
            {
                if (await _chapterRepository.GetChapterById(chapterDto.ChapterId) == null)
                {
                    ChapterDTO model = await _chapterRepository.CreateChapter(chapterDto);
                    _response.Result = model;
                }
                else
                {
                    throw new Exception("This chapter is exist");
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

        [HttpDelete("DeleteChapter/{id}")]
        [Authorize(Roles = "1")]
        public async Task<object> DeleteChapter(int id)
        {
            try
            {
                if (await _chapterRepository.GetChapterById(id) != null)
                {
                    bool isSuccess = await _chapterRepository.DeleteChapter(id);
                    _response.Result = isSuccess;
                    if (!isSuccess)
                    {
                        throw new Exception("Can't delete");
                    }
                }
                else
                {
                    throw new Exception("This story is NOT exist");
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
