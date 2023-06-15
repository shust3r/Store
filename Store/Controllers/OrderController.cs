﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Store_DataAccess.Repository.IRepository;
using Store_Models.ViewModels;
using Store_Utility;
using Store_Utility.BrainTree;
using System.Linq;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderHeaderRepository _orderHRepo;
        private readonly IOrderDetailRepository _orderDRepo;
        private readonly IBrainTreeGate _brain;

        public OrderController(IOrderHeaderRepository orderHRepo, IOrderDetailRepository orderDRepo, IBrainTreeGate brain)
        {
            _orderHRepo = orderHRepo;
            _orderDRepo = orderDRepo;
            _brain = brain;
        }


        public IActionResult Index()
        {
            OrderListVM orderListVM = new OrderListVM()
            {
                OrderHList = _orderHRepo.GetAll(),
                StatusList = WC.listStatus.ToList().Select(i => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            return View(orderListVM);
        }
    }
}
