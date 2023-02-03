using DoAn1.Models;
using DoAn1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.Controllers
{
    public class ProductController : Controller
    {
        private readonly DoAn1Context _context;
        public ProductController(DoAn1Context context)
        {
            _context = context;
        }
        public IActionResult MListProducts()
        {
            return View(_context.sqlMListProducts());
        }
        public IActionResult MListCheckProducts()
        {

            var query = from agent in _context.Agents
                        join product in _context.Products
                        on agent.AgentId equals product.AgentId
                        where product.Status == 0
                        select new
                        {
                            product.ProductId,
                            product.ProductName,
                            agent.AgentName,

                        };
            return View(query);
        }

        [HttpGet]
        public IActionResult MDetailProduct(int ProductId)
        {
            var record = _context.sqlMDetailProduct(ProductId);
            if (record == null)
            {
                return NotFound();
            }
            return View(record);
        }


        [HttpGet]
        public IActionResult SetStatusProduct(int ProductId, int Status)
        {
            int prod = _context.sqlCheckExistProduct(ProductId);

            if (prod == 0)
            {
                return NotFound(ProductId);
            }

            if (_context.sqlSetStatusProduct(ProductId, Status) == 1)
            {
                return RedirectToAction(nameof(MListCheckProducts));
            }
            else
            {
                return Json("Lỗi khi cập nhật. Vui lòng thử lại ! <3");
            }
        }
    }
}
