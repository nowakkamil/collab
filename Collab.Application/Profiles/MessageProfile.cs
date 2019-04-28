using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>()
                .ReverseMap();
        }
    }
}
