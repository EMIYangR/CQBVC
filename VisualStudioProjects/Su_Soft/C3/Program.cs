using System;

namespace C3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "I am a student";
            string[] words = str.Split(' '); 
            Array.Reverse(words); 
            Console.WriteLine(string.Join(" ", words)); 
        }
    }
}
