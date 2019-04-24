using AutoMapper;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProjectService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return project;
            }

            return null;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _dbContext.Projects
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            return project;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var projects = await _dbContext.Projects.ToListAsync();

            return projects;
        }

        public async Task<Project> UpdateProjectAsync(Project projectForUpdate)
        {
            var project = await _dbContext.Projects
                .FirstOrDefaultAsync(a => a.Id == projectForUpdate.Id);

            if (project == null)
            {
                return null;
            }

            project.Name = projectForUpdate.Name;
            project.Description = projectForUpdate.Description;
            _dbContext.Entry(project).State = EntityState.Modified;

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return project;
            }

            return null;
        }

        public async Task<bool> DeleteProjectByIdAsync(int id)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(a => a.Id == id);

            if (project == null)
            {
                return false;
            }

            _dbContext.Remove(project);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
