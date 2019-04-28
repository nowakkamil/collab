using System.Collections.Generic;

namespace Collab.Data.Entities
{
    public class Hashtag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
