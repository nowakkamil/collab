using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Collab.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public virtual ICollection<Article> Articles { get; set; }
    }
}
