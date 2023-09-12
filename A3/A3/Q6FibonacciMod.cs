using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
            List<long> s = new List<long>();
            s.Add(0);
            s.Add(1);
            long n = 0, m = 1;

            while (true)
            {
                if(s.Count > 2 && s[s.Count - 2] == 0 && s[s.Count - 1] == 1)
                    break;
                (n, m) = (m, (m + n)%b);
                s.Add(m);
            }
            return s[(int)(a % (s.Count - 2))];
        }
    }
}
