using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class ComplateOrder
    {
        public ComplateOrder() { }
        public ComplateOrder(string fullname, string telephone,string address,string paymethod,string productname, int quantity, double total, DateTime orderdate)
        {
            this.FullName = fullname;
            this.Telephone = telephone;
            this.Address = address;
            this.ProductName = productname;
            this.OrderDate = orderdate;
            this.Total = total;
            this.PayMethod = paymethod;
            this.Quantity = quantity;
        }
        [Display(Name = "Tên")]
        public string FullName { get; set; }
        [Display(Name = "Số điện thoại")]
        public string Telephone { get; set; }
        [Display(Name = "Thông tin nhận hàng")]
        public string Address { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Ngày đặt")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        [Display(Name ="Tổng tiền")]
        public double Total { get; set; }
        [Display(Name ="Phương thức thanh toán")]
        public string PayMethod {get; set;}




    }
}
