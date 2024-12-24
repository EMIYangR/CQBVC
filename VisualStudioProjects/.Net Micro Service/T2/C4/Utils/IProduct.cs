using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C4.Utils
{
    public interface IProduct
    {
        int ID { get; set; }
        string Name { get; set; }
        ICategory Category { get; set; }
        decimal Price { get; set; }
    }
}
