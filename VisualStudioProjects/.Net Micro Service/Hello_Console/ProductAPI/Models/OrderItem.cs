using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAPI.Models
{
    [Table("OrderItem")]
    public partial class OrderItem
    {
        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column(TypeName = "money")]
        public decimal PayMoney { get; set; }
        public int Num { get; set; }
        [Column("OrderID")]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderItems")]
        public virtual Order Order { get; set; }
    }
}
