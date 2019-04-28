using Collab.Application.Dtos;
using Collab.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IHashtagService
    {
        Task<Hashtag> CreateHashtagAsync(Hashtag hashtag);
        Task<Hashtag> AddArticleToHashtagAsync(int articleId, string hashtagName);
        Task<Hashtag> GetHashtagByIdAsync(int id);
        Task<Hashtag> GetHashtagByNameAsync(string hashtagName);
        Task<List<Article>> GetArticlesByHashtagName(string hashtagName);
        Task<bool> DeleteHashtagByIdAsync(int id);
        Task<bool> DeleteHashtagByNameAsync(string hashtagName);
    }
}
