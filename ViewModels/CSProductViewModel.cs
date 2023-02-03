using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class CSProductViewModel
    {
        public CSProductViewModel(int id, string prname,double unitprice, string agtname, string des)
        {
            this.ProductId = id;
            this.ProductName = prname;
            this.Unitprice = unitprice;
            this.AgentName = agtname;
            this.Description = des;
        }
        public CSProductViewModel()
        {

        }
        public int ProductId { get; set; }
        
        [Display(Name ="Tên sản phẩm")]
        public string ProductName { get; set; }


        [Display(Name = "Tên chủ tiệm")]
        public string AgentName { get; set; }

        [Display(Name ="Giá")]
        public double Unitprice { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    }
}
