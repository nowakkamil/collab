using System.Collections.Generic;

namespace Collab.Application.Dtos
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public virtual List<ArticleDto> Articles { get; set; }
    }
}
