using System;

namespace nums
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter n: ");
            long n = long.Parse(Console.ReadLine());
            long sum = (long)n*(n + 1)/2;
            for (int i = 0; i < n - 1; i++)
                sum -= long.Parse(Console.ReadLine());
            System.Console.WriteLine($"The unlisted number is {sum}.");
        }
    }
}
