using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T6_2.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
