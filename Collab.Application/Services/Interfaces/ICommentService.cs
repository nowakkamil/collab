using Collab.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Collab.Data.Entities;

namespace Collab.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(CommentDto commentDto);
        Task<CommentDto> DeleteCommentByIdAsync(int? id);
        Task<Comment> EditCommentAsync(CommentDto projectDto);
    }
}
