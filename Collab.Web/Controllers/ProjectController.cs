using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Collab.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService ??
                throw new ArgumentNullException(nameof(projectService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectDto projectDto)
        {
            {
                var project = await _projectService.CreateProjectAsync(projectDto);

                if (project == null)
                {
                    return NotFound();
                }

                return Ok(project);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectById(int id)
        {
            var project = await _projectService.DeleteProjectByIdAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> EditProject(ProjectDto projectDto)
        {
            {
                var project = await _projectService.EditProjectAsync(projectDto);

                if (project == null)
                {
                    return NotFound();
                }

                return Ok(project);
            }
        }


    }
}