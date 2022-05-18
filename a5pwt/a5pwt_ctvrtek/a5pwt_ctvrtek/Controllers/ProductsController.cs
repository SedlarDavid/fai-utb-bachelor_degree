using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a5pwt_ctvrtek.Application.ApplicationServices.Products;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductsController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        public IActionResult Index()
        {
            var vm = _productApplicationService.GetIndexViewModel();
            return View(vm);
        }

        public IActionResult Detail(int id)
        {
            var vm = _productApplicationService.GetProductViewModel(id);
            return View(vm);
        }
    }
}