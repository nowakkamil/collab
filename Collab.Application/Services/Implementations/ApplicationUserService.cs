using Collab.Application.Services.Interfaces;
using Collab.Data;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Collab.Application.Services.Implementations
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _singInManager;

        public ApplicationUserService(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> singInManager)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _singInManager = singInManager ??
                throw new ArgumentNullException(nameof(singInManager));
        }

        public async Task<IdentityResult> CreateApplicationUserAsync(
            ApplicationUser applicationUser, string password)
        {
            var identityResult = await _userManager.CreateAsync(applicationUser, password);

            return identityResult;
        }

        public async Task<ApplicationUser> GetApplicationUserByIdAsync(int userId)
        {
            var applicationUser = await _userManager.FindByIdAsync(userId.ToString());

            if (applicationUser == null)
            {
                return null;
            }

            applicationUser.Articles = await _dbContext.Articles
                .Where(a => a.ApplicationUser.Id == userId)
                .ToListAsync();

            return applicationUser;
        }

        public async Task<ApplicationUser> GetApplicationUserByEmailAsync(string email)
        {
            var applicationUser = await _userManager.FindByEmailAsync(email);

            return applicationUser;
        }
    }
}
