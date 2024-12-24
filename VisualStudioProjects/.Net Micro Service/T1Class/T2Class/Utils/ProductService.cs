using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2Class.Models;

namespace T2Class.Utils
{
    public class ProductService : IProductService
    {
        public IEnumerable<Goods> GetAllGoods()
        {
            return new List<Goods>()
            {
                new Goods(1,"苹果1个",2),
                new Goods(2,"手机一部",1999),
                new Goods(3,"电脑一台",3999)
            };
        }
    }
}
