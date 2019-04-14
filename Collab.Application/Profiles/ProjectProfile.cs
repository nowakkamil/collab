using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Profiles
{
    class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}
