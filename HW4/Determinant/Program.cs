using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Determinan
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Func<double[,], double>, double> funcs = new Dictionary<Func<double[,], double>, double>();
            funcs.Add(Det0, 0);
            funcs.Add(Det1, 0);
            funcs.Add(Det2, 0);
            Stopwatch s = new Stopwatch();

            for (int j = 0; j < 10; j++)
            {
                int i = 1;
                var a = RandomMatrix(10);
                Console.WriteLine($"Matrix {j + 1}:\n");
                PrintMatrix(a);
                foreach (var func in funcs.Keys.ToList())
                {
                    var b = (double[,]) a.Clone();  
                    s.Start();
                    // double d = func(b); روش دوم و سوم به علت داشتن عملیات تقسیم در خود، دارای کمی خطا هستند
                    double d = Math.Round(func(b));
                    s.Stop();
                    double time = s.ElapsedMilliseconds;
                    System.Console.WriteLine($"algorythm {i++}\ndeterminant = {d}\ntime elapsed: {time} ms\n\n");
                    funcs[func] += time;
                    s.Reset(); 
                }
            }
            int k = 0;
            foreach (var func in funcs)
                Console.WriteLine($"average runtime algorythm {k++}: {func.Value/10} ms");

            // int n = int.Parse(Console.ReadLine());
            // double[,] mat = new double[n ,3];
            // for (int i = 0; i < n; i++)
            // {
            //     var a = Array.ConvertAll(Console.ReadLine().Split(), double.Parse);
            //     for (int j = 0; j < 3; j++)
            //         mat[i, j] = a[j];
            // }

            // double d = Det1(mat);
            // Console.Write(d);
        }

        private static void PrintMatrix(double[,] a)
        {
            int n = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{a[i, j]} ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static double[,] RandomMatrix(int n)
        {
            double[,] a = new double[n, n];
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    a[i, j] = r.Next()%15;
            }
            return a;
        }
        // algorythm 1, time complexity = n!
        public static double Det0(double[,] a)
        {
            int n = a.GetLength(1);
            if(n == 1)
                return a[0,0];
            if(n == 2)
                return a[0,0]*a[1,1] - a[0,1]*a[1,0];
            double d = 0;
            for(int i = 0; i < n; i++)
            {
                double[,] b = MakeMatrix(a, i, 0);
                d += (long)Math.Pow(-1, i)*a[0,i]*Det0(b);
            }
            return d;
        }
        // algorythm 2, time complexity = n^3
        public static double Det1(double[,] a)
        {
            int n = a.GetLength(1), t = 0;
            if(n == 1)
                return a[0,0];
            for (int i = 0; i < n; i++)
            {
                if(a[i,0] != 0)
                {
                    t = i;
                    break;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if(i != t && a[i, 0] != 0)
                {
                    double k = a[i, 0]/a[t, 0];
                    for (int j = 0; j < n; j++)
                        a[i, j] -= a[t, j]*k;
                }
            }
            return Math.Pow(-1, t)*a[t, 0]*Det1(MakeMatrix(a, 0, t));
        }
        // algorythm 3 rezaifar
        public static double Det2(double[,] a)
        {
            int n = a.GetLength(1) - 1;
            if(n == 0)
                return a[0,0];
            if(n == 1)
                return a[0,0]*a[1,1] - a[0,1]*a[1,0];
            double[,] b = MakeMatrix(a, 0, 0);
            double oneone = Det2(b),
            nn = Det2(MakeMatrix(a, n, n)),
            one_n = Det2(MakeMatrix(a, n, 0)),
            n_one = Det2(MakeMatrix(a, 0, n));
            return (oneone*nn - one_n*n_one)/Det2(MakeMatrix(b, n, n));
        }

        private static double[,] MakeMatrix(double[,] a, int k, int r)
        {
            int n = a.GetLength(1);
            double[,] b = new double[n - 1, n - 1];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if(j < k && i < r)
                        b[i, j] = a[i, j];
                    else if(j < k)
                        b[i, j] = a[i + 1, j];
                    else if(i < r)
                        b[i, j] = a[i, j + 1];
                    else
                        b[i, j] = a[i + 1, j + 1];
                }
            }
            return b;
        }
    }
}
