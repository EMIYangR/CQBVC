using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAPI.Models
{
    [Table("ProductClass")]
    [Index(nameof(ClassName), Name = "IX_ProductClass", IsUnique = true)]
    public partial class ProductClass
    {
        public ProductClass()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("ClassID")]
        public int ClassId { get; set; }
        [Required]
        [StringLength(16)]
        public string ClassName { get; set; }
        [Column("ParentClassID")]
        public int ParentClassId { get; set; }

        [InverseProperty(nameof(Product.Class))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
