using System;
using TestCommon;

namespace C7
{
    public class Q1HungryFrog : Processor
    {
        public Q1HungryFrog(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


        public virtual long Solve(long n, long p, long[][] numbers)
        {
            long[][] dp = new long[2][];
            dp[0] = new long[n];
            dp[1] = new long[n];
            (dp[0][0], dp[1][0]) = (numbers[0][0], numbers[1][0]);
            for (int i = 1; i < n; i++)
            {
                dp[0][i] = Math.Max(dp[0][i - 1], dp[1][i - 1] - p) + numbers[0][i];
                dp[1][i] = Math.Max(dp[1][i - 1], dp[0][i - 1] - p) + numbers[1][i];
            }
            return Math.Max(dp[0][n - 1], dp[1][n - 1]);
        }
    }
}
