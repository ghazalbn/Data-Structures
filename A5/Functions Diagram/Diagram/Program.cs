using System;

namespace Diagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 0 for quick mode, or 1 for step by step mode: ");
            int mode = int.Parse(Console.ReadLine());

            Console.Write("Please enter a function: ");
            Expression e = new Expression(Console.ReadLine(), mode);
            Console.WriteLine("postfix of function: " + e.st.Postfix);

            Console.Write("Specify the range of x, enter first and last digit of the range whit a space: ");
            var period = Array.ConvertAll(Console.ReadLine().Split(), float.Parse);
            (float x0, float x1) = (period[0], period[1]);

            Console.Write("enter number of points: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var paint = new PaintRoom(e);
            paint.Draw(x0, x1, n);
            
            // File.Delete(@".\diagram.png");
            Console.ReadKey();
        }
    }
}
