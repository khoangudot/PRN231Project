using AutoMapper;
using BussinessObjects.Dtos;
using DataAccess.DbContexts;
using DataAccess.Entities;
using DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CommentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddComment(AddCommentDTO comment)
        {
            try
            {
                var c = _mapper.Map<AddCommentDTO, Comment>(comment);
                c.ParentCommentId = null;
                c.CreatedAt = DateTime.Now;
                _context.Comments.Add(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddReply(AddCommentDTO comment)
        {
            try
            {
                var parentComment = await _context.Comments.FindAsync(comment.ParentCommentId);
                if (parentComment != null)
                {
                    var reply = _mapper.Map<Comment>(comment);
                    reply.ParentCommentId = comment.ParentCommentId;
                    reply.CreatedAt = DateTime.Now;
                    _context.Comments.Add(reply);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            try
            {
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == commentId);
                if (comment != null)
                {
                    var replies = await _context.Comments.Where(x => x.StoryId == comment.StoryId && x.ParentCommentId == comment.CommentId).ToListAsync();
                    if (replies.Any())
                    {
                        _context.Comments.RemoveRange(replies);
                    }
                }
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditComment(AddCommentDTO comment)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CommentDTO>> GetComments(int storyId)
        {
            try
            {
                var comments = await _context.Comments
                    .Include(x => x.User).Include(c => c.ParentComment)
                    .Where(x => x.StoryId == storyId && x.ParentCommentId == null).ToListAsync();
                var commentDTOs = _mapper.Map<List<CommentDTO>>(comments);
                foreach (var commentDTO in commentDTOs)
                {
                    commentDTO.ListReplies = GetReplies(commentDTO.CommentId);
                }
                return commentDTOs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<ReplyDTO> GetReplies(int commentId)
        {
            var replies = _context.Comments
                .Include(x => x.User)
                .Where(c => c.ParentCommentId == commentId)
                .Select(c => _mapper.Map<ReplyDTO>(c))
                .ToList();
            return replies;
        }
    }
}
