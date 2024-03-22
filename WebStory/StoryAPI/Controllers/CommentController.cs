using BussinessObjects.Dtos;
using DataAccess.Repository.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        protected ResponseDto _response;
        private ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
            _response = new ResponseDto();
        }

        [HttpGet("GetComments/{storyId}")]
        [AllowAnonymous]
        public async Task<object> GetComments(int storyId)
        {
            try
            {
                var result = await _commentRepository.GetComments(storyId);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddComment")]
        [Authorize]
        public async Task<object> AddComment([FromBody] AddCommentDTO comment)
        {
            try
            {
                var result = await _commentRepository.AddComment(comment);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost("AddReply")]
        [Authorize]
        public async Task<object> AddReply([FromBody] AddCommentDTO comment)
        {
            try
            {
                var result = await _commentRepository.AddReply(comment);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("DeleteComment/{commentId}")]
        [Authorize]
        public async Task<object> DeleteComment(int commentId)
        {
            try
            {
                var result = await _commentRepository.DeleteComment(commentId);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

    }
}
