using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Collab.Data;
using Collab.Data.Entities;
using System.Linq;

namespace Collab.Application.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            await _dbContext.Articles.AddAsync(article);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return article;
            }

            return null;
        }

        public async Task<List<Article>> GetAllArticlesAsync()
        {
            var articles = await _dbContext.Articles.ToListAsync();
        
            return articles;
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            var article = await _dbContext.Articles
                .Where(a => a.Id == id)
                .Include(a => a.ApplicationUser)
                .FirstOrDefaultAsync();

            return article;
        }

        public async Task<Article> UpdateArticleAsync(Article articleForUpdate)
        {
            var article = await _dbContext.Articles
                .FirstOrDefaultAsync(a => a.Id == articleForUpdate.Id);

            if (article == null)
            {
                return null;
            }

            article.Content = articleForUpdate.Content;
            _dbContext.Entry(article).State = EntityState.Modified;

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return article;
            }

            return null;
        }

        public async Task<bool> DeleteArticleByIdAsync(int id)
        {
            var article = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);

            if (article == null)
            {
                return false;
            }

            _dbContext.Articles.Remove(article);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
