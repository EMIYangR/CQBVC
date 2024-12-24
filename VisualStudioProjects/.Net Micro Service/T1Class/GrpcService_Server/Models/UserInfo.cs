using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace GrpcService_Server.Models
{
    [Table("UserInfo")]
    [Index(nameof(UserId), Name = "IX_UserInfo")]
    [Index(nameof(UserName), Name = "IX_UserInfo_1", IsUnique = true)]
    public partial class UserInfo
    {
        public UserInfo()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(16)]
        public string UserName { get; set; }
        [Required]
        [StringLength(32)]
        public string UserPwd { get; set; }
        [Column("QQ")]
        [StringLength(16)]
        public string Qq { get; set; }
        [StringLength(16)]
        public string Phone { get; set; }
        [StringLength(64)]
        public string Address { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }

        [InverseProperty(nameof(Comment.User))]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
