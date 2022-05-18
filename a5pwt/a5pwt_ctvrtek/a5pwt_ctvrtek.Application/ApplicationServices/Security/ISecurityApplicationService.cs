using a5pwt_ctvrtek.Application.ViewModels.Security;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Security
{
    public interface ISecurityApplicationService
    {
        Task RegisterAndLogin(LoginViewModel viewModel);
        Task Logout();
        Task<bool> Login(LoginViewModel viewModel);
        Task<User> GetCurrentUser(ClaimsPrincipal principal);
        Task<User> GetUserByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
    }
}
