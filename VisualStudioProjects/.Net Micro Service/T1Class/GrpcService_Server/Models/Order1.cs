using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GrpcService_Server.Models
{
    [Keyless]
    [Table("Order1")]
    public partial class Order1
    {
        [Column("oId")]
        public int? OId { get; set; }
        [Column("pId")]
        public int? PId { get; set; }
        [Column("uId")]
        public int? UId { get; set; }
    }
}
