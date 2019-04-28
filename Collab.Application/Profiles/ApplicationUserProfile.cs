using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ReverseMap();
        }
    }
}
