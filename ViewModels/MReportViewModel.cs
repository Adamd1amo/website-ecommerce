using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn1.ViewModels
{
    public class MReportViewModel
    {
        [Display(Name ="Số đơn đặt hàng thành công")]
        int NumberOfSuccessfulOrders { get; set; }
        [Display(Name = "Số đơn đặt hàng bị hủy")]
        int NumberOfCanceledOrders { get; set; }
        [Display(Name = "Lợi nhuận tháng này")]
        decimal Revenue { get; set; }
        [Display(Name = "Số lượng khách hàng mới")]
        int NumberOfNewCustomer { get; set; }
        [Display(Name = "Số lượng chủ tiệm mới")]
        int NumberOfNewAgent { get; set; }
        [Display(Name = "Tổng số khách hàng")]
        int TotalCustomers { get; set; }
        [Display(Name = "Số lượng khách hàng mới")]
        int TotalAgents { get; set; }
    }
}
