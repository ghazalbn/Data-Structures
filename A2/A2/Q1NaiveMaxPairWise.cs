using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q1NaiveMaxPairWise : Processor
    {
        public Q1NaiveMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            int n = numbers.Length;
            long p = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    long m = numbers[i] * numbers[j];
                    if (p < m)
                    p = m;
                }
            }
            return p;
        }
    }
}

