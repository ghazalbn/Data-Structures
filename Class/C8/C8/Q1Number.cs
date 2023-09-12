using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C8
{
    public class Q1Number : Processor
    {
        public Q1Number(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long>)Solve);

        public long Solve(long nodeCount, long[][] edges)
        {
            return 0;
        }
    }
}
