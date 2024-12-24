using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace T4
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string LoginID { get; set; }
        public string LoginPwd { get; set; }
        public string UserName { get; set; }
    }
}
