using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace T3_3.Models
{
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddTime { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Total { get; set; }
    }
}
