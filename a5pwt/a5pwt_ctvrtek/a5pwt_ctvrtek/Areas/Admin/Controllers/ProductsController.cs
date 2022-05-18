using a5pwt_ctvrtek.Application.ApplicationServices.Products;
using a5pwt_ctvrtek.Application.ViewModels.Products;
using a5pwt_ctvrtek.Areas.Admin.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace a5pwt_ctvrtek.Areas.Admin.Controllers
{
    public class ProductsController : AdminController
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

        public IActionResult Edit(int id)
        {
            var vm = _productApplicationService.GetProductViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            var product = _productApplicationService.Edit(model);

            return Json(product);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(ProductViewModel model)
        {
            var product = _productApplicationService.Insert(model);

            return Json(product);
        }

        public IActionResult Delete(ProductViewModel model)
        {
            _productApplicationService.Delete(model);

            return RedirectToAction(nameof(Index));
        }
    }
}