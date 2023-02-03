using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class OrderDetail
    {
        public int Orderid { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
