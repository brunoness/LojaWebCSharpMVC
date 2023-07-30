using LojaWebCSharp.Models;
using LojaWebCSharp.Models.ViewModels;
using LojaWebCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaWebCSharp.Controllers {
    public class VendedoresController : Controller {

        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService) {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index() {

            var list = _vendedorService.FindAll();
            return View(list);
        }

        public IActionResult Create() {
            var departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor) {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var obj = _vendedorService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            _vendedorService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
