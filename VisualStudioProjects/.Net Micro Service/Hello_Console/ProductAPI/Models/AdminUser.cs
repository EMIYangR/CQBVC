﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProductAPI.Models
{
    [Table("AdminUser")]
    public partial class AdminUser
    {
        [Key]
        [Column("AdminID")]
        public int AdminId { get; set; }
        [Required]
        [StringLength(16)]
        public string AdminName { get; set; }
        [Required]
        [StringLength(32)]
        public string AdminPwd { get; set; }
    }
}