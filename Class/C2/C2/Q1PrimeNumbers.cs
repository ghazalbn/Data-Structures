using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C2
{
    public class Q1PrimeNumbers : Processor
    {
        public Q1PrimeNumbers(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string>) Solve);

        public static string Solve(string a)
        {
            int n = int.Parse(a);
            int i = 2;
            string s = "";
            while(n > 1)
            {
                if(n % i == 0)
                {
                    int pow = 0;
                    while(n%i == 0)
                    {
                        n /= i;
                        pow++;
                    }
                    s += $"*{i}^{pow}";
                }
                i++;
            }
            return s.Replace("^1", "").TrimStart('*');
        }
    }
}
