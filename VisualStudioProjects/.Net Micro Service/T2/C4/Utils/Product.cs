using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C4.Utils
{
    public class Product:IProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICategory Category { get; set; }
        public decimal Price { get; set; }

        public Product(ICategory category)
        {
            this.Category = category;
        }
    }
}
