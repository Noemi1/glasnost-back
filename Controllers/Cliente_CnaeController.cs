using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace glasnost_back.Controllers
{
    public class Cliente_CnaeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
