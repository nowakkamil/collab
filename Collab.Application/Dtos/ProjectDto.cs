using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
