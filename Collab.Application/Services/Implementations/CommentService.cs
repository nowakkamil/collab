using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {           
            await _dbContext.AddAsync(comment);

            if (await _dbContext.SaveChangesAsync() > 0)
            {

                return comment;
            }

            return null;
        }

        public async Task<Comment> DeleteCommentByIdAsync(int id)
        {
            if (id == null)
            {
                return null;
            }

            var comment = await _dbContext.Comments.FindAsync(id);

            if (comment == null)
            {
                return null;
            }

            _dbContext.Remove(comment);

            await _dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> EditCommentAsync(Comment comment)
        {

            
            _dbContext.Update(comment);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return comment;
            }

            return null;
        }
    }
}

