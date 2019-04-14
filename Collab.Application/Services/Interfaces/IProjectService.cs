using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectByIdAsync(int? id);
        Task<Project> CreateProjectAsync(ProjectDto projectDto);
        Task<ProjectDto> DeleteProjectByIdAsync(int? id);
        Task<Project> EditProjectAsync(ProjectDto projectDto);
    }
}
