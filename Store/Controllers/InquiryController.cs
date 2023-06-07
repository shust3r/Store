using Microsoft.AspNetCore.Mvc;
using Store_Models;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Store_Utility;
using Store_DataAccess;
using Store_DataAccess.Repository.IRepository;

namespace Store.Controllers
{

    public class InquiryController : Controller
    {
        private readonly IInquiryHeaderRepository _inqHRepo;
        private readonly IInquiryDetailRepository _inqDRepo;

        public InquiryController(IInquiryDetailRepository inqDRepo, IInquiryHeaderRepository inqHRepo)
        {
            _inqDRepo = inqDRepo;
            _inqHRepo = inqHRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
