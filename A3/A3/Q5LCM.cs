using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            return (long)a*b/gcd(a, b);
        }
        private static long gcd(long a, long b)
        {
            if(a < b)
                (a, b) = (b, a);
            if(b == 0)
                return a;
            return gcd(a%b, b);
        }

    }
}
