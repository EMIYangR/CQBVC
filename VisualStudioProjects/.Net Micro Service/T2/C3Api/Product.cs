using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C3.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDesc { get; set; }

        public Product()
        {

        }
        public Product(int ProductID, string ProductName, decimal ProductPrice,string ProductDesc)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
            this.ProductDesc = ProductDesc;
        }
    }
}
