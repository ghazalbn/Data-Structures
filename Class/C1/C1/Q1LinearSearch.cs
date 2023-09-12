using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q1LinearSearch : Processor
    {
        public Q1LinearSearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            int length = numbers.Length;
            for(int i = 0; i < length; i++)
            {
                if(numbers[i] == a[1])
                    return i;
            }
            return -1;
        }
    }
}
