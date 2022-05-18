using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.ApplicationServices.Security;
using a5pwt_ctvrtek.Application.ViewModels.Security;
using a5pwt_ctvrtek.Areas.Admin.Controllers.Common;
using a5pwt_ctvrtek.Domain.Constants;
using a5pwt_ctvrtek.Infrastructure.Identity.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class SecurityController : AdminController
    {
        private readonly ISecurityApplicationService _securityApplicationService;

        public SecurityController(ISecurityApplicationService securityApplicationService)
        {
            _securityApplicationService = securityApplicationService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _securityApplicationService.Login(vm);
            if (result)
            {
                var user = await _securityApplicationService.GetUserByEmail(vm.Login);
                var roles = await _securityApplicationService.GetUserRoles(user);
                if (roles.Contains(Roles.Admin) || roles.Contains(Roles.Manager))
                    return RedirectToAction("Index", "Products", new { area = "Admin" });
                return RedirectToAction("Index", "Products", new { area = "" });
            }
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Logout()
        {
            await _securityApplicationService.Logout();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel vm)
        {
            await _securityApplicationService.RegisterAndLogin(vm);

            return RedirectToAction("Index", "Products", new { area = "" });
        }
    }
}