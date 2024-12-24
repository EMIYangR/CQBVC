using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace T2Class.Models
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("CommentID")]
        public int CommentId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string CommentContent { get; set; }
        public int Star { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CommentTime { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Comments")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(UserInfo.Comments))]
        public virtual UserInfo User { get; set; }
    }
}
