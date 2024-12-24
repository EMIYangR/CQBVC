using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAPI.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [StringLength(64)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(64)]
        public string ProductPic { get; set; }
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string ProductDesc { get; set; }
        [Column("ClassID")]
        public int ClassId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AddTime { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty(nameof(ProductClass.Products))]
        public virtual ProductClass Class { get; set; }
        [InverseProperty(nameof(Comment.Product))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
