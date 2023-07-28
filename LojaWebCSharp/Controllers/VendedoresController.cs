using LojaWebCSharp.Models;
using LojaWebCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebCSharp.Controllers {
    public class VendedoresController : Controller {

        private readonly VendedorService _vendedorService;

        public VendedoresController(VendedorService vendedorService) {
            _vendedorService = vendedorService;
        }
        public IActionResult Index() {

            var list = _vendedorService.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor) {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
