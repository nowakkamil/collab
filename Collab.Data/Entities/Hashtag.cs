using System;
using System.Collections.Generic;
using System.Text;

namespace Collab.Data.Entities
{
    public class Hashtag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Article> Articles { get; set; }
    }
}
