using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ReverseMap();
        }
    }
}
