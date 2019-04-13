using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Collab.Data;
using Collab.Application.Dto;

namespace Collab.Application.Services.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ApplicationUserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApplicationUserDto> GetApplicationUserByIdAsync(int id)
        {
            var applicationUser = await _dbContext.ApplicationUsers
                .FirstOrDefaultAsync(x => x.Id == id.ToString());

            return _mapper.Map<ApplicationUserDto>(applicationUser);
        }
    }
}
