using System;
using TestCommon;
using System.Linq;

namespace C3
{
    public class Q1MaximumPerimeterTriangle : Processor
    {
        public Q1MaximumPerimeterTriangle(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Solve(long len,long[] edges)
        {
            if(len == 2)
                return new long[1]{-1};
            if(len == edges.Length)
                Array.Sort(edges);
            if(edges[len - 1] < edges[len - 2] + edges[len - 3])
                return new long[3]{edges[len - 3], edges[len - 2], edges[len - 1]};
            return Solve(len - 1, edges);
        }
    }
}
