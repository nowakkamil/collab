namespace Collab.Data.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Content { get; set; }
    }
}
