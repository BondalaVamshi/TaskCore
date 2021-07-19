using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using CheeseMVC.ViewModel;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CheeseController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IList<Cheese> cheeses = _db.Cheese.Include(m => m.Category).ToList();
            return View(cheeses);
        }
        //public IActionResult Add()
        //{
        //    CheeseViewModel cheese = new CheeseViewModel(_db.CheeseCategory.ToList());
        //    return View(cheese);
        //}
    }
}
