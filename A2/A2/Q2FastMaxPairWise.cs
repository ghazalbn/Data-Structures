using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            int n = numbers.Length;
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                if(numbers[i] > numbers[m])
                    m = i;
            }
            int p = -1;
            for (int i = 0; i < n; i++)
            {
                if (i != m && (p == -1 || numbers[p] < numbers[i]))
                    p = i;
            }
            return numbers[p] * numbers[m];
        }
    }
}
