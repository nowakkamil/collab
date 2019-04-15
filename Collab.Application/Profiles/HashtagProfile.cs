using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Profiles
{
    public class HashtagProfile : Profile
    {
        public HashtagProfile()
        {
            CreateMap<HashtagDto, Hashtag>();
            CreateMap<Hashtag, HashtagDto>();
        }
    }
}
