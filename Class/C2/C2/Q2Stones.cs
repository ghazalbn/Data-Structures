using System;
using System.Collections.Generic;
using TestCommon;

namespace C2
{
    public class Q2Stones : Processor
    {
        public Q2Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
            long sum = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                sum += stones[i];
                if(sum >= n)
                    return i + 1;
            }
            return 0;
        }
    }
}
