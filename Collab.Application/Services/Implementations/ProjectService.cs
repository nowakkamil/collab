using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProjectService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ProjectDto> GetProjectByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var project = await _dbContext.Projects
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<Project> CreateProjectAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _dbContext.AddAsync(project);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return project;
            }

            return null;
        }

        public async Task<ProjectDto> DeleteProjectByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var project = await _dbContext.Projects.FindAsync(id);

            if (project == null)
            {
                return null;
            }

            _dbContext.Remove(project);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<Project> EditProjectAsync(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            _dbContext.Update(projectDto);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return project;
            }

            return null;

        }
    }
}
