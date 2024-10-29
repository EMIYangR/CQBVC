using System;

namespace C5
{
    class Promage
    {
        //A在初始化时使用了B的值，但是B还未初始化，此时B使用默认值0，因此A的值为0*10=0
        static readonly int B = 10;
        static readonly int A = B * 10;
        public static void Main(string[] args)
        {
            
            Console.WriteLine("A = {0}; B ={1}", A, B);
            Console.ReadLine();
        }
    }

}
