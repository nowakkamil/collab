using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDto>()
            .ReverseMap();
        }
    }
}
