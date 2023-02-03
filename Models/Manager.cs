using System;
using System.Collections.Generic;

#nullable disable

namespace DoAn1.Models
{
    public partial class Manager
    {
        public int ManagerId { get; set; }
        public string UserId { get; set; }
        public byte Status { get; set; }
    }
}
