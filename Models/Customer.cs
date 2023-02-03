using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerPayments = new HashSet<CustomerPayment>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public byte Age { get; set; }

        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
