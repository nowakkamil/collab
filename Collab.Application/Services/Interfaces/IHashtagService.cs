using Collab.Application.Dtos;
using Collab.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IHashtagService
    {
        Task<HashtagDto> GetHashtagByIdAsync(int id);
        Task<HashtagDto> CreateHashtagAsync(HashtagDto hashtagDto);
        
    }
}
