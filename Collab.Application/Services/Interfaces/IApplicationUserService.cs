using Collab.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Collab.Application.Services
{
    public interface IApplicationUserService
    {
        Task<IdentityResult> CreateApplicationUserAsync(ApplicationUser applicationUser, string password);
        Task<ApplicationUser> GetApplicationUserByIdAsync(int id);
        Task<ApplicationUser> GetApplicationUserByEmailAsync(string email);
    }
}
