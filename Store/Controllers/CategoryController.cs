using Microsoft.AspNetCore.Mvc;
using Store_Models;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Store_Utility;
using Store_DataAccess;
using Store_DataAccess.Repository.IRepository;
using Microsoft.Extensions.Localization;

namespace Store.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _catRepo;
        private readonly IStringLocalizer<CategoryController> _localizer;

        public CategoryController(ICategoryRepository catRepo, IStringLocalizer<CategoryController> localizer)
        {
            _catRepo = catRepo;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _catRepo.GetAll();
            return View(objList);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                _catRepo.Add(obj);
                _catRepo.Save();
                TempData[WC.Success] = _localizer["SuccessCreate"].ToString();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = _localizer["ErrorCreate"].ToString();
            return View(obj);
        }

        //GET - Edit
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _catRepo.Update(obj);
                _catRepo.Save();
                TempData[WC.Success] = _localizer["SuccessEdit"].ToString();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = _localizer["ErrorEdit"].ToString();
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _catRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                TempData[WC.Error] = _localizer["NotFound"].ToString();
                return NotFound();
            }
            _catRepo.Remove(obj);
            _catRepo.Save();
            TempData[WC.Success] = _localizer["SuccessDelete"].ToString();
            return RedirectToAction("Index");
        }
    }
}
