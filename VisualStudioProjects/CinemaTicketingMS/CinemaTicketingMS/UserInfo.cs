using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketingMS
{
    public class UserInfo
    {
        private int UserID;
        private string UserName;
        private string UserNickName;
        private string UserAccount;
        private string UserPwd;
        private string UserPhone;

        public int UserID1 { get => UserID; set => UserID = value; }
        public string UserName1 { get => UserName; set => UserName = value; }
        public string UserNickName1 { get => UserNickName; set => UserNickName = value; }
        public string UserAccount1 { get => UserAccount; set => UserAccount = value; }
        public string UserPwd1 { get => UserPwd; set => UserPwd = value; }
        public string UserPhone1 { get => UserPhone; set => UserPhone = value; }
    }
}
