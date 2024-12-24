using Grpc.Net.Client;
using GrpcService_Client.Models;
using GrpcService_Product_Server;
using GrpcService_Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService_Client.Controllers
{
    public class HomeController : Controller
    {
        Greeter.GreeterClient client = null;
        ProductManager.ProductManagerClient clientProduct = null;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            client = new Greeter.GreeterClient(channel);
        }

        public IActionResult Index()
        {
            // 按照GRPC发起请求
            var helloRequest = new HelloRequest()
            {
                Name = "张三"
            };
            HelloReply helloReply = client.SayHello(helloRequest);

            ViewBag.Message = helloReply.Message;

            var pr = new ProductRequest();
            ProductReply pre = clientProduct.GetProductByID(pr);
            AllProductsReply apr = clientProduct.GetProductAll(new Google.Protobuf.WellKnownTypes.Empty());

            return View(apr.Product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
