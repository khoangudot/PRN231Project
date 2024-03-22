﻿using BussinessObjects.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepositories
{
    public interface ICommentRepository
    {
        public Task<bool> AddComment(AddCommentDTO comment);

        public Task<bool> AddReply(AddCommentDTO comment);

        public Task<bool> EditComment(AddCommentDTO comment);

        public Task<bool> DeleteComment(int commentId);

        public Task<List<CommentDTO>> GetComments(int storyId);
    }
}
