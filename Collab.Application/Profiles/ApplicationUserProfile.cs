using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Collab.Application.Dto;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<ApplicationUserDto, ApplicationUser>();
        }
    }
}
