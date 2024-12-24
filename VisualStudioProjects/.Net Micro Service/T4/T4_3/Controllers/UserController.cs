using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using T4;

namespace T4_3.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string loginId,string loginPwd)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new T4.UserManagerService.UserManagerServiceClient(channel);
            var request = new LoginRequest()
            {
                LoginId = loginId,
                LoginPwd = loginPwd
            };
            var resp = client.Login(request);
            if (resp.UserName!="")
            {
                return View(resp);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
