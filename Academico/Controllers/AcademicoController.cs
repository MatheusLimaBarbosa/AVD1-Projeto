using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Controllers
{
    public class AcademicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
