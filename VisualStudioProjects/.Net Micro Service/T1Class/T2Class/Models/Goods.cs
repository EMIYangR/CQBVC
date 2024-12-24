using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2Class.Models
{
    public class Goods
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public decimal GoodsPrice { get; set; }
        public Goods()
        {

        }
        public Goods(int GoodsID,string GoodsName, decimal GoodsPrice)
        {
            this.GoodsID = GoodsID;
            this.GoodsName = GoodsName;
            this.GoodsPrice = GoodsPrice;
        }
    }
}
