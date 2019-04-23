using Collab.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Dtos
{
   public class CommentDto
    {
        public string Content { get; set; }        
        public DateTime DateofMade { get; set; }
        public DateTime DateOfEdit { get; set; }

        public ApplicationUserDto User { get; set; }
        //prop atricle

    }
}
