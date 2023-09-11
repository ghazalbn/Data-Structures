using System;

namespace reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a word end with a point:");
            Reverse();
        }
        public static void Reverse()
        {
            char s = Console.ReadKey().KeyChar;
            if(s != '.')
            {
                Reverse();
                Console.Write(s);
            }
            else Console.WriteLine();
        }
    }
}
