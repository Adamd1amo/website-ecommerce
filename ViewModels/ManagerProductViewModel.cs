using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class ManagerProductViewModel
    {
        public ManagerProductViewModel(int id, string nameprod, decimal price, string des, string agent, string cate)
        {
            this.ProductId = id;
            this.ProductName = nameprod;
            this.UnitPrice = price;
            this.Description = des;
            this.AgentName = agent;
            this.CategoryName = cate;
        }
        public int ProductId { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Giá sản phẩm")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Tên cửa tiệm")]
        public string AgentName { get; set; }

        [Display(Name = "Danh mục")]
        public string CategoryName { get; set; }
    }
}
