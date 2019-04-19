using Collab.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collab.Application.Services
{
    public interface IArticleService
    {
        Task<Article> CreateArticleAsync(Article article);
        Task<Article> GetArticleByIdAsync(int id);
        Task<List<Article>> GetAllArticlesAsync();
        Task<Article> UpdateArticleAsync(Article article);
        Task<bool> DeleteArticleByIdAsync(int id);
    }
}
