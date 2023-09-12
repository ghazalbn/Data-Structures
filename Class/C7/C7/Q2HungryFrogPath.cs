using System;
using TestCommon;

namespace C7
{
    public class Q2HungryFrogPath : Processor
    {
        public Q2HungryFrogPath(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long[]>)Solve);


        public static long[] Solve(long n, long p, long[][] numbers)
        {
            long[][] dp = new long[2][];
            long[][] parents = new long[2][];
            dp[0] = new long[n];
            dp[1] = new long[n];
            (dp[0][0], dp[1][0]) = (numbers[0][0], numbers[1][0]);
            parents[0] = new long[n];
            parents[1] = new long[n];
            (parents[0][0], parents[1][0]) = (0, 1);
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if(dp[j][i - 1] > dp[1 - j][i - 1] - p)
                    {
                        dp[j][i] = numbers[j][i] + dp[j][i - 1];
                        parents[j][i] = j; 
                    }
                    else
                    {
                        dp[j][i] = numbers[j][i] + dp[1 - j][i - 1] - p;
                        parents[j][i] = 1 - j; 
                    }
                }
            }
            long[] res = new long[n];
            res[n - 1] = dp[0][n - 1] > dp[1][n - 1]? 0: 1;
            for(int i = (int)n - 2; i >= 0; i--)
                res[i] = parents[res[i + 1]][i + 1];
            return res;
        }
    }
}
