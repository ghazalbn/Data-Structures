using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace C1
{
    public class Q2BinarySearch : Processor
    {
        public Q2BinarySearch(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>) Solve);

        public static long Solve(long[] a, long[] numbers)
        {
            return BinarySearch(a, numbers, 0, (int)a[0]);
        }

        private static long BinarySearch(long[] a, long[] numbers, int left, int right)
        {
            if(left >= right - 1)
                return -1;
            int index = (left+right)/2;
            if(a[1] < numbers[index])
                return BinarySearch(a, numbers, left, index);
            if(a[1] > numbers[index])
                return BinarySearch(a, numbers, index, right);
            return index;
        }
    }
}
