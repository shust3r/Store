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
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository _appTypeRepo;
        private readonly IStringLocalizer<ApplicationTypeController> _localizer;

        public ApplicationTypeController(IApplicationTypeRepository appTypeRepo, IStringLocalizer<ApplicationTypeController> localizer)
        {
            _appTypeRepo = appTypeRepo;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _appTypeRepo.GetAll();
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
        public IActionResult Create(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Add(obj);
                _appTypeRepo.Save();
                TempData[WC.Success] = _localizer["SuccessCreateHTTPPost"].ToString();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = _localizer["ErrorCreateHTTPPost"].ToString();
            return View(obj);
        }

        //GET - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _appTypeRepo.Update(obj);
                _appTypeRepo.Save();
                TempData[WC.Success] = _localizer["SuccessEditHTTPPost"].ToString();
                return RedirectToAction("Index");
            }
            TempData[WC.Error] = _localizer["ErrorEditHTTPPost"].ToString();
            return View(obj);
        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
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
            var obj = _appTypeRepo.Find(id.GetValueOrDefault());
            if (obj == null)
            {
                TempData[WC.Error] = _localizer["NotFound"].ToString();
                return NotFound();
            }
            _appTypeRepo.Remove(obj);
            _appTypeRepo.Save();
            TempData[WC.Success] = _localizer["SuccessDeleteHTTPPost"].ToString();
            return RedirectToAction("Index");
        }
    }
}
