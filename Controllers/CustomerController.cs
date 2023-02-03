using DoAn1.Areas.Identity.Data;
using DoAn1.Models;
using DoAn1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<DoAn1User> _userManager;
        private readonly SignInManager<DoAn1User> _signInManager;
        private readonly DoAn1Context _context;
        [TempData]
        public string StatusMessage { get; set; }
        public CustomerController(DoAn1Context context, UserManager<DoAn1User> userManager, SignInManager<DoAn1User> signInManager)
        {
            _context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View(_context.sqlCSListProducts());
        }
        public IActionResult DisplayProducts()
        {
           
            return View(_context.sqlCSListProducts());
        }

        public IActionResult InforProduct(int ProductId)
        {

            return View(_context.sqlInforProduct(ProductId));
        }
        [Authorize]
        public IActionResult OrderProduct(CSProductViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                string fullname = _context.sqlFullName(_context.sqlCustomerId(_userManager.GetUserId(User)));
                OrderProductViewModel ordermodel = new OrderProductViewModel(model, fullname);
                return View(ordermodel);
            }
            else return Redirect("~/Identity/account/login");
        }

        [HttpPost]
        public IActionResult OrderProduct(int ProductId, int Quantity, double Unitprice,string Address, string Telephone, string Pay)
        {
            string mess = "";
            int cusID = _context.sqlCustomerId(_userManager.GetUserId(User));
            if (_context.sqlCreateOrder(cusID, Address, Telephone, ref mess) != 0)
            {
                int orderid = _context.sqlGetOrderID();
                if (_context.sqlCreateOrderDetail(orderid, ProductId, Quantity, Unitprice, ref mess) != 0)
                {
                    TempData["StatusMessage"] = mess;
                    return RedirectToAction("OrderProduct");
                }
                else
                {
                    TempData["StatusMessage"] = mess;
                    return RedirectToAction("OrderProduct");
                }

            }
            else
            {
                TempData["StatusMessage"] = mess;
                return RedirectToAction("OrderProduct");
            }
            
        }

        public string CompleteOrder(string mess)
        {
            return mess;
        }
        public IActionResult InforAgent(int AgentId)
        {
            return View();
        }

        public IActionResult ListOfOrder()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View("Profile");
        }

    }
}
