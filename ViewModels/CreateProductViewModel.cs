using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class CreateProductViewModel
    {

        [Display(Name = "Tên sản phẩm")]
        [StringLength(30, ErrorMessage = "Số lượng kí tự không vượt quá 30")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Danh mục")]
        [Required]
        public string CategoryName { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Range(0, int.MaxValue,ErrorMessage ="Giá phải là số dương")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(10, ErrorMessage = "Số lượng ký tự phải từ 5 đến 50 ký tự")]
        public string Description { get; set; }

    }
}
