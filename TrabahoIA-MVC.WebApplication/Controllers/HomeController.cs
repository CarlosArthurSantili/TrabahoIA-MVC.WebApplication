using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrabahoIA_MVC.WebApplication.Models;

namespace TrabahoIA_MVC.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static FrontModel Front;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Algoritmos() 
        {            
            Front = new FrontModel();
            return View(Front);
        }

        [HttpPost]
        public IActionResult Algoritmos(FrontModel atualizaFront)
        {
            if(atualizaFront.AlgoritmoEscolhido == "Algoritmo2")
            {
                //this.Front = new FrontModel();
                ViewBag.caminho = Front.AlgoritmoDeLargura(atualizaFront.VerticeDestino);
                ViewBag.caminho2 = Front.CaminhoToString(atualizaFront.VerticeDestino);
            }          
            return View(Front);
        }

        public IActionResult BuscaLargura()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
