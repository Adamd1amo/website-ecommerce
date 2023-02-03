using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class CustomerPayment
    {
        public string PaymentId { get; set; }
        public int? CustomerId { get; set; }
        public string PaymentType { get; set; }
        public string Provider { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
