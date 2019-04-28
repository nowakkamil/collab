using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    public class HashtagProfile : Profile
    {
        public HashtagProfile()
        {
            CreateMap<Hashtag, HashtagDto>()
                .ReverseMap();
        }
    }
}
