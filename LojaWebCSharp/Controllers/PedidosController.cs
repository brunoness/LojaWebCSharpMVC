﻿using LojaWebCSharp.Services;
using Microsoft.AspNetCore.Mvc;


namespace LojaWebCSharp.Controllers {
    public class PedidosController : Controller {

        private readonly PedidoService _pedidoService;

        public PedidosController(PedidoService pedidoService) {
            _pedidoService = pedidoService;
        }
        public IActionResult Index() {
            return View();
        }
        public async Task<IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _pedidoService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> BuscaAgrupada(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _pedidoService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
