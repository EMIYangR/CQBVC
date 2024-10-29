using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            String name = "daniel";
            int salary = 3400;
            double subsidyPrice = salary * 0.2;
            double subsidyHouse = salary * 0.4;
            double actualSalary = salary + subsidyPrice + subsidyHouse;
            Console.WriteLine("姓名：\n" + name);
            Console.WriteLine("实际工资：\n" + actualSalary);
        }
    }
}
