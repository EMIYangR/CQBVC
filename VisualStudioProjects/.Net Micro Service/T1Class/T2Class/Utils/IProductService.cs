using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2Class.Models;

namespace T2Class.Utils
{
     public interface IProductService
    {
        IEnumerable<Goods> GetAllGoods();
    }
}
