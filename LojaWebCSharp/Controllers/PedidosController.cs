﻿using Microsoft.AspNetCore.Mvc;

namespace LojaWebCSharp.Controllers {
    public class PedidosController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult BuscaSimples() {
            return View();
        }
        public IActionResult BuscaAgrupada() {
            return View();
        }
    }
}
