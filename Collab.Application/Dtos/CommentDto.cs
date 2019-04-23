using Collab.Application.Dto;
using System;

namespace Collab.Application.Dtos
{
    public class CommentDto
    {
        public string Content { get; set; }        
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }

        public ApplicationUserDto ApplicationUserDto { get; set; }
        //prop atricle

    }
}
