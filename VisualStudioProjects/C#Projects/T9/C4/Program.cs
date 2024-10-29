using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C4
{
    class Program
    {
        public static string Encrypt(string data)
        {
            char[] charData = data.ToArray();
            int[] intData = new int[8];
            for (int i = 0; i < charData.Length; i++)
            {
                intData[i] = int.Parse(charData[i].ToString());
            }
            for (int i = 0; i < intData.Length; i++)
            {
                intData[i] = (intData[i] + 5) % 10;
            }
            int temp = intData[0];
            intData[0] = intData[7];
            intData[7] = temp;
            string newData = "";
            for (int i = 0; i < intData.Length; i++)
            {
                newData += intData[i].ToString();
            }
            return newData;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个八位整数：");
            string Pwd = Console.ReadLine();
            Console.WriteLine("加密后的数据：\n"+Encrypt(Pwd));
        }
    }
}
