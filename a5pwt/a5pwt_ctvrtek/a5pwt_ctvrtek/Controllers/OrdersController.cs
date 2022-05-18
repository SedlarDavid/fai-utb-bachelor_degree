using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.ApplicationServices.Orders;
using a5pwt_ctvrtek.Application.ApplicationServices.Security;
using a5pwt_ctvrtek.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderApplicationService _orderApplicationService;
        private readonly ISecurityApplicationService _securityApplicationService;

        public OrdersController(IOrderApplicationService orderApplicationService,
            ISecurityApplicationService securityApplicationService)
        {
            _orderApplicationService = orderApplicationService;
            _securityApplicationService = securityApplicationService;
        }

        public async Task<IActionResult> Create()
        {
            var user = await _securityApplicationService.GetCurrentUser(User);
            _orderApplicationService.CreateOrder(
                user.Id,
                Request.Cookies[Cookies.UserTrackingCode]
                );

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var user = await _securityApplicationService.GetCurrentUser(User);
            var vm = _orderApplicationService.GetIndexViewModel(user.Id);
            return View(vm);
        }
    }
}