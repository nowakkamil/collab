using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService ??
                throw new ArgumentNullException(nameof(commentService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommentById(Comment comment)
        {

           await _commentService.CreateCommentAsync(comment);         

            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentById(int id)
        {
            var comment = await _commentService.DeleteCommentByIdAsync(id);

            if (comment == null)
                return NotFound();

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(CommentDto commentDto)
        {
            var comment = await _commentService.EditCommentAsync(commentDto);

            if (comment == null)
            {
                return NotFound();
            }
                
            return Ok(comment);
        }
    }
}