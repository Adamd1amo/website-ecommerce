using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class Agent
    {
        public Agent()
        {
            Products = new HashSet<Product>();
        }

        public int AgentId { get; set; }
        public string UserId { get; set; }
        public string AgentName { get; set; }
        public string Mail { get; set; }
        public int Star { get; set; }
        public byte Status { get; set; }
        public string Introduction { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
