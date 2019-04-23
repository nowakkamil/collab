using Collab.Application.Dtos;
using Collab.Data.Entities;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> CreateCommentAsync(Comment comment);
        Task<CommentDto> DeleteCommentByIdAsync(int id);
        Task<Comment> EditCommentAsync(CommentDto projectDto);
    }
}


