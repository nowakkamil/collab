using Collab.Data.Entities;
using System.Collections.Generic;

namespace Collab.Application.Dtos
{
    public class HashtagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
