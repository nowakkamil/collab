using Collab.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Collab.Application.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<IdentityResult> CreateApplicationUserAsync(ApplicationUser applicationUser, string password);
        Task<ApplicationUser> GetApplicationUserByIdAsync(int id);
        Task<ApplicationUser> GetApplicationUserByEmailAsync(string email);
    }
}
