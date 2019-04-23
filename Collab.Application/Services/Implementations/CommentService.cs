using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<Comment> CreateCommentAsync(CommentDto projectDto)
        {
            var comment = _mapper.Map<Comment>(projectDto);
            await _dbContext.AddAsync(comment);

            if (await _dbContext.SaveChangesAsync() > 0)
            {

               return comment;
            }

            return null;

        }

        public async Task<CommentDto> DeleteCommentByIdAsync(int? id)
        {

            if (id == null)            
            return null;

            var comment = await _dbContext.Comments.FindAsync(id);
                
            if (comment == null)           
            return null;
            

            _dbContext.Remove(comment);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CommentDto>(comment);

        }

        public async Task<Comment> EditCommentAsync(CommentDto commentDto)

        {

           var project = _mapper.Map<Comment>(commentDto);

           _dbContext.Update(commentDto);

            if (await _dbContext.SaveChangesAsync() > 0)         
            return project;
            
            return null;

        }



    }

}

