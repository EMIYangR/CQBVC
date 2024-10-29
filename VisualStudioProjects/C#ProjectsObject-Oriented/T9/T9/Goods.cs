using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9 
{
    class Goods
    {
        private int id;
        private string name;
        private double price;
        private string inpuduce;

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Inpuduce { get => inpuduce; set => inpuduce = value; }
        public int Id { get => id; set => id = value; }
        public override string ToString()
        {
            return string.Format("编号：{0}\r\n名称：{1}\r\n价格：{2}\r\n简介：{3}\r\n",this.Id,this.Name,this.Price,this.Inpuduce);
        }
    }
}
