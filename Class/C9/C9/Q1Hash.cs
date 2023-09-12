using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace C9
{
    public class Q1Hash : Processor
    {
        public Q1Hash(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string,string, long>)Solve);

        public long Solve(string s1, string s2)
        {
            if(s1.Length > s2.Length)
                (s2, s1) = (s1, s2);
            int count = 0;
            for (int i = 1; i <= s1.Length; i++)
            {
                if (s1.Length % i == 0 && s2.Length % i == 0)
                {
                    string s = s1.Substring(0, i);
                    bool flag = false;
                    for (int j = i; j < s1.Length; j+=i)
                    {
                        string subs1 = s1.Substring(j, i);
                        if (DJB.GetHash(s) != DJB.GetHash(subs1))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if(!flag)
                    {
                        for (int j = 0; j < s2.Length; j+=i)
                        {
                            string subs2 = s2.Substring(j, i);
                            if (DJB.GetHash(s) != DJB.GetHash(subs2))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (!flag) count++;
                }
            }
            return count;
        }
    }
}
