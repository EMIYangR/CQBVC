using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAPI.Models
{
    [Keyless]
    [Table("orderDetail")]
    public partial class OrderDetail
    {
        [Column("odId")]
        public int? OdId { get; set; }
        [Column("oid")]
        public int? Oid { get; set; }
        [Column("pid")]
        public int? Pid { get; set; }
        [Column("count")]
        public int? Count { get; set; }
    }
}
