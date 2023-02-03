using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public byte? Age { get; set; }
        public byte? Gender { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
