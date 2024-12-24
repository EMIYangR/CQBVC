using C3.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    public IEnumerable<Product> Get()
    {
        List<Product> p = new List<Product>
            {
                new Product
                {
                    ProductID=1,
                    ProductName="iQOO 11S",
                    ProductPrice=5499,
                    ProductDesc="第十九届杭州亚运会电子竞技项目官方指定用机"
                },
                new Product
                {
                    ProductID=2,
                    ProductName="iQOO 11",
                    ProductPrice=5498,
                    ProductDesc="KPL2023春季赛官方指定用机"
                },
                new Product
                {
                    ProductID=3,
                    ProductName="vivo X90",
                    ProductPrice=6599,
                    ProductDesc="vivo全新旗舰手机"
                },
                new Product
                {
                    ProductID=4,
                    ProductName="HUAWEI Mate 60",
                    ProductPrice=6999,
                    ProductDesc="第十九届杭州亚运会赛事报道指定用机"
                },
            };
        return p;
    }
}
