using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace T2Class.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderTime { get; set; }
        [Column(TypeName = "money")]
        public decimal OrderMoney { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserInfo.Orders))]
        public virtual UserInfo User { get; set; }
        [InverseProperty(nameof(OrderItem.Order))]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
