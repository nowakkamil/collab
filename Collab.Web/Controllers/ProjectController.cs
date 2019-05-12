using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collab.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService ??
                throw new ArgumentNullException(nameof(projectService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            project = await _projectService.CreateProjectAsync(project);

            if (project == null)
            {
                return NotFound();
            }

            projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();

            if (projects == null)
            {
                return NotFound();
            }

            var projectDtos = _mapper.Map<List<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody]ProjectDto projectDto)
        {
            var project = await _projectService
                .UpdateProjectAsync(_mapper.Map<Project>(projectDto));

            if (project == null)
            {
                return NotFound();
            }

            projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            var result = await _projectService.DeleteProjectByIdAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
