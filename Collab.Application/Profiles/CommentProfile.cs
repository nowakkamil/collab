using AutoMapper;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Collab.Application.Dto;
using Collab.Application.Dtos;

namespace Collab.Application.Profiles
{
    class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentProfile, CommentDto>();
            CreateMap<CommentDto, CommentProfile>();
        }
    }
}
