using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web_app_mvc.Controllers
{
    public class ArtigoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
