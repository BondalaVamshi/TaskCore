using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CheeseCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
