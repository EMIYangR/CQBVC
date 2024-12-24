using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C4.Utils
{
    public class Category:ICategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Category()
        {
            this.ID = 0;
            this.Name = "电子产品";
        }
    }
}
