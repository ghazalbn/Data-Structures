using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long a = 0, b = 1;

            for (int i = 0; i < n; i++)
            {
                (a, b) = (b, a + b);
                // b += a;
                // a = b - a;  
            }
            return a;
        }
    }
}
