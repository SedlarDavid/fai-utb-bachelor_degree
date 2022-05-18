using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.ApplicationServices.Carts;
using a5pwt_ctvrtek.Application.ApplicationServices.Security;
using a5pwt_ctvrtek.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartApplicationService _cartApplicationService;
        private readonly ISecurityApplicationService _securityApplicationService;

        public CartsController(ICartApplicationService cartApplicationService,
            ISecurityApplicationService securityApplicationService)
        {
            _cartApplicationService = cartApplicationService;
            _securityApplicationService = securityApplicationService;
        }

        public async Task<IActionResult> Index()
        {
            var vm = _cartApplicationService.GetIndexViewModel(GetOrCreateTrackingCode());
            var user = await _securityApplicationService.GetCurrentUser(User);
            if (user != null)
            {
                vm.UserID = user.Id;
                vm.UserEmail = user.Email;
            }

            return View(vm);
        }

        [HttpPost]
        public JsonResult AddToCart(int id, int amount)
        {
            var cartItem = _cartApplicationService.AddToCart(id, amount, GetOrCreateTrackingCode());

            return Json(cartItem);
        }

        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            _cartApplicationService.RemoveFromCart(id, GetOrCreateTrackingCode());
            return Json("success");
        }

        private string GetOrCreateTrackingCode()
        {
            var utc = Request.Cookies[Cookies.UserTrackingCode];
            if (utc != null)
                return utc;

            var guid = Guid.NewGuid().ToString();
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddYears(1);

            Response.Cookies.Append(Cookies.UserTrackingCode, guid, options);
            return guid;
        }
    }
}