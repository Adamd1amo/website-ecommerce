using DoAn1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class OrderProductViewModel
    {
        public OrderProductViewModel(CSProductViewModel model,string fullname)
        {
            this.productViewModel = model;

            this.FullName = fullname;
        }
        [Display(Name ="Số điện thoại")]
        public string Telephone { get; set; }
        [Display(Name ="Tên")]
        public string FullName { get; set; }
        [Display(Name = "Thông tin nhận hàng")]
        public string Address { get; set; }

        [Display(Name ="Số lượng")]
        [Range(1,100, ErrorMessage ="Số lượng phải từ 1 trở lên")]
        public int Quantity { get; set;}

        public CSProductViewModel productViewModel { get; set; }

    }
}
