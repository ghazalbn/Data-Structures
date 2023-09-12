using System;
using System.Collections.Generic;

namespace coin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("enter n: ");
            int n = int.Parse(Console.ReadLine());
            coins(0, 0, 0, 2, n);
        }
        public static void coins(int a, int b, int c, int pointer, int n) 
        {
            if(n < 0)
                return;
            if(n == 0)
                System.Console.WriteLine($"{a} ta 10 riali, {b} ta 5 riali, {c} ta 2 riali.");
            else
            {
                if(pointer == 2)
                    coins(a, b, c+1, 2, n-2);
                if(pointer != 10)
                    coins(a, b+1, c, 5, n-5);
                coins(a+1, b, c, 10, n-10);
            }
        }
    }
}
