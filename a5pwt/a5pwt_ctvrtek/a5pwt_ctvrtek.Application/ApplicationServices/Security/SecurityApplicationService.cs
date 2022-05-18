using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.ViewModels.Security;
using a5pwt_ctvrtek.Domain.Constants;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Identity;

namespace a5pwt_ctvrtek.Application.ApplicationServices.Security
{
    public class SecurityApplicationService : ISecurityApplicationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public SecurityApplicationService(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
            => _userManager.GetUserAsync(principal);

        public Task<User> GetUserByEmail(string email)
            => _userManager.FindByEmailAsync(email);

        public Task<IList<string>> GetUserRoles(User user)
            => _userManager.GetRolesAsync(user);

        public async Task<bool> Login(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                viewModel.Login,
                viewModel.Password,
                viewModel.RememberMe,
                true);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterAndLogin(LoginViewModel viewModel)
        {
            var user = new User
            {
                Email = viewModel.Login,
                UserName = viewModel.Login,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.User);
            }
            await Login(viewModel);
        }
    }
}
