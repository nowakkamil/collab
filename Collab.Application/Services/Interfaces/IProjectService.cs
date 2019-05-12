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
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> GetProjectByIdAsync(int id);
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> UpdateProjectAsync(Project projectForUpdate);
        Task<bool> DeleteProjectByIdAsync(int id);
    }
}
