using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using System.Collections.Generic;
using System.Collections;

namespace Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }
    }
}
