using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionPlaneacionDidacticaAPI.Controllers
{

    public class IndexController : Controller
    {
        public IActionResult MetIndex()
        {
            return View();
        }
    }
}