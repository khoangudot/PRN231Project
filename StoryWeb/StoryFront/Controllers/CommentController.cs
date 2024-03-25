using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ObjectModel.Dtos;
using StoryFront.Helpers;
using StoryFront.Services.IServices;

namespace StoryFront.Controllers
{
    public class CommentController : Controller
    {

        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> AddReply(AddCommentDTO add)
        {
            var token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                return RedirectToAction("Login", "Auth", new { Value = "" });
            }
            var userId = CheckService.GetUserId(token);
            add.UserId = userId;
            var c = await _commentService.AddReplyAsync<ResponseDto>(add, token);
            if (c.IsSuccess)
            {
                return RedirectToAction("MangaDetail", "Manga", new { StoryId = add.StoryId});
            }

            return BadRequest();
        }

        public async Task<IActionResult> AddComment(AddCommentDTO add)
        {
            var token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                return RedirectToAction("Login", "Auth" ,new {Value = ""});
            }

            var userId = CheckService.GetUserId(token);
            add.UserId = userId;
            var c = await _commentService.AddCommentAsync<ResponseDto>(add, token);
            if (c.IsSuccess)
            {
                return RedirectToAction("MangaDetail", "Manga", new { StoryId = add.StoryId });
            }

            return BadRequest();
        }

        public async Task<IActionResult> DeleteComment(int detailId, int commentId)
        {
            var token = HttpContext.Session.GetString("token");
            if (token == null)
            {
                return RedirectToAction("Login", "Auth" ,new {Value = ""});
            }

            var c = await _commentService.DeleteCommentAsync<ResponseDto>(commentId, token);
            if (c.IsSuccess)
            {
                return RedirectToAction("MangaDetail", "Manga", new { StoryId = detailId });
            }

            return BadRequest();
        }

    }
}
