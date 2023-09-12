using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;
using System.Linq;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
            if(n < 2)
                return a;
            long[] arr1 = Solve(n/2, new ArraySegment<long>(a, 0, (int)n/2).ToArray());
            long[] arr2 = Solve(n - n/2, new ArraySegment<long>(a, (int)n/2, (int)(n - n/2)).ToArray());
            long[] arr = new long[n];
            
            int k = 0, i = 0, j = 0;
            while (i < n - n/2 && j < n/2)
            {
                if (arr2[i] <= arr1[j]) 
                {
                    arr[k] = arr2[i];
                    i++;
                }
                else
                {
                    arr[k] = arr1[j];
                    j++;
                }
                k++;
            }
            while (i < n - n/2) 
            {
                arr[k] = arr2[i];
                i++;
                k++;
            }
            while (j < n/2)
            {
                arr[k] = arr1[j];
                j++;
                k++;
            }
            return arr;
        }
    }
}
