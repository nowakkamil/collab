using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Application.Dtos
{
    public class HashtagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
