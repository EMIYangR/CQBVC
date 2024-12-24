using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GrpcService_Server.Models
{
    [Keyless]
    public partial class VProductProductClass
    {
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
        [StringLength(16)]
        public string ClassName { get; set; }
        [Column("ParentClassID")]
        public int? ParentClassId { get; set; }
    }
}
