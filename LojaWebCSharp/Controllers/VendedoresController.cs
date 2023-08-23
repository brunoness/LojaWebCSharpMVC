using LojaWebCSharp.Models;
using LojaWebCSharp.Models.ViewModels;
using LojaWebCSharp.Services;
using LojaWebCSharp.Services.Excessoes;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaWebCSharp.Controllers {
    public class VendedoresController : Controller {

        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService) {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }
        public async Task<IActionResult> Index() {

            var list = await _vendedorService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor) {

            if (!ModelState.IsValid) {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorService.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou não informado." });               
            }

            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não existe." });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) {
            await _vendedorService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou não informado." });
            }
            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não existe." });
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou não informado." });
            }
            var obj = await _vendedorService.FindByIdAsync(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id não existe." });
            }

            List<Departamento> departamentos = await _departamentoService.FindAllAsync();
            VendedorFormViewModel vielModel = new VendedorFormViewModel {Vendedor = obj, Departamentos = departamentos };
            return View(vielModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor) {
            if (!ModelState.IsValid) {
                var departamentos =  await _departamentoService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            if (id != vendedor.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id's não correspondem." });
            }
            try {
                await _vendedorService.UpdateAsync(vendedor);
                return RedirectToAction(nameof(Index));
            } 
            catch (ApplicationException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            } 

        }

        public IActionResult Error(string message) {
            var vielModel = new ErrorViewModel {

                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(vielModel);
        }
    }
}
