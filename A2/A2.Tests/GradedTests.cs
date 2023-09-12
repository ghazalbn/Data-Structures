using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1500)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
            Random r = new Random();
            Stopwatch s = Stopwatch.StartNew();
            while (s.Elapsed < TimeSpan.FromSeconds(5))
            {
                int n = r.Next(2, 10);
                long[] numbers = new long[n];
                for (int i = 0; i < n; i++)
                    numbers[i] = r.Next(0, 50);
                long a = new Q1NaiveMaxPairWise("").Solve(numbers);
                long b = new Q2FastMaxPairWise("").Solve(numbers);
                if(a != b)
                {
                    System.Console.WriteLine($"Q1 = {a}, Q2 = {b}");
                    break;
                }
            }
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}