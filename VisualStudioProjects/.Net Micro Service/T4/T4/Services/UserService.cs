using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace T4
{
    public class UserService : UserManagerService.UserManagerServiceBase
    {
        public override Task<LoginRespose> Login(LoginRequest request,
            ServerCallContext context)
        {
            string loginId = request.LoginId;
            string loginPwd = PasswordEncryption(request.LoginPwd);

            var options = new DbContextOptionsBuilder<UserContext>();
            var db = new UserContext(
                options.UseSqlServer("server=.,database=ShoppingDB, User Id = sa, PasswordEncryption = 123456").Options);
            var user = db.Users.SingleOrDefault(u => u.LoginID == loginId && u.LoginPwd == loginPwd);

            return Task.FromResult<LoginRespose>(new LoginRespose
            {
                UserName = user.UserName
            });
        }

        private string PasswordEncryption(string pwd)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] originalPwd = Encoding.UTF8.GetBytes(pwd);
            byte[] encryPwd = sha1.ComputeHash(originalPwd);
            return string.Join("", encryPwd.Select(b => string.Format("{0:x2}", b)).ToArray()).ToUpper();
        }
    }
}
