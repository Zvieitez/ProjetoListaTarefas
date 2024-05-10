using Microsoft.AspNetCore.Mvc;
using ProjetoListaTarefas.Models;
using System.Diagnostics;

namespace ProjetoListaTarefas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var images = new List<ImageModel>
            {
                new ImageModel{ ImagePath = "img/Foto01.jpg"},
            };
            return View(images);
        }

        public IActionResult Privacy()
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
