using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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


        public async Task<HashtagDto> CreateHashtagAsync(HashtagDto hashtagDto)
        {
            var newHashtag = _mapper.Map<Hashtag>(hashtagDto);
            await _dbContext.AddAsync(newHashtag);
            await _dbContext.SaveChangesAsync();

            return hashtagDto;
        }

        public async Task<HashtagDto> GetHashtagByIdAsync(int id)
        {
            var hashtag = await _dbContext.Hashtags
                .FirstOrDefaultAsync(h => h.Id == id);

            return _mapper.Map<HashtagDto>(hashtag);
        }
    }
}
