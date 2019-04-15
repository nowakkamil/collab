using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>();
            CreateMap<Message, MessageDto>();
        }
    }
}
