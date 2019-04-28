using AutoMapper;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class HashtagService : IHashtagService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public HashtagService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Hashtag> CreateHashtagAsync(Hashtag hashtag)
        {
            await _dbContext.AddAsync(hashtag);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return hashtag;
            }

            return null;
        }

        public async Task<Hashtag> AddArticleToHashtagAsync(int articleId, string hashtagName)
        {
            var hashtag = _dbContext.Hashtags.FirstOrDefault(h => h.Name.Equals(hashtagName));

            if (hashtag == null)
            {
                return null;
            }

            var article = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

            if (article == null)
            {
                return null;
            }

            hashtag.Articles.Add(article);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return hashtag;
            }

            return null;
        }

        public async Task<Hashtag> GetHashtagByIdAsync(int id)
        {
            var hashtag = await _dbContext.Hashtags
                .FirstOrDefaultAsync(h => h.Id == id);

            return hashtag;
        }

        public async Task<List<Article>> GetArticlesByHashtagName(string hashtagName)
        {
            var hashtag = await _dbContext.Hashtags
                .Include(h => h.Articles)
                .FirstOrDefaultAsync(h => h.Name.Equals(hashtagName));

            if (hashtag == null)
            {
                return null;
            }

            return hashtag.Articles.ToList();
        }

        public async Task<Hashtag> GetHashtagByNameAsync(string hashtagName)
        {
            var hashtag = await _dbContext.Hashtags
                .FirstOrDefaultAsync(h => h.Name.Equals(hashtagName));

            return hashtag;
        }

        public async Task<bool> DeleteHashtagByIdAsync(int id)
        {
            var hashtag = await _dbContext.Hashtags.FirstOrDefaultAsync(h => h.Id == id);

            if (hashtag == null)
            {
                return false;
            }

            _dbContext.Hashtags.Remove(hashtag);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteHashtagByNameAsync(string hashtagName)
        {
            var hashtag = await _dbContext.Hashtags.FirstOrDefaultAsync(h => h.Name.Equals(hashtagName));

            if (hashtag == null)
            {
                return false;
            }

            _dbContext.Hashtags.Remove(hashtag);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
