using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sistema_Cadastro_Clientes.Controllers
{
    public class MainPageController: Controller {
        private readonly ILogger<MainPageController> _logger;

        public MainPageController(ILogger<MainPageController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }



    }
    
}