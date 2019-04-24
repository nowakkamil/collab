using Collab.Application.Dto;
using System.Threading.Tasks;

namespace Collab.Application.Services
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDto> GetApplicationUserByIdAsync(int id);
    }
}
