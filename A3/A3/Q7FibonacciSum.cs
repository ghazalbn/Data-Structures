using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q7FibonacciSum : Processor
    {
        public Q7FibonacciSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            List<long> s = new List<long>();
            s.Add(0);
            s.Add(1);
            long a = 0, b = 1;

            while (true)
            {
                if(s.Count > 2 && s[s.Count - 2] == 0 && s[s.Count - 1] == 1)
                    break;
                (a, b) = (b, (a + b)%10);
                s.Add(b);
            }
            return (s[(int)((n + 2)% (s.Count - 2))] + 9) % 10;
        }
    }
}
