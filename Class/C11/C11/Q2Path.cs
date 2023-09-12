using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C11
{
    public class Q2Path : Processor
    {
        public Q2Path(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[][], long, long, string>)Solve);


        public string Solve(long nodeCount, long[][] edges, long startNode, long endNode)
        {
            //Your code
            throw new NotImplementedException();
        }
    }
}