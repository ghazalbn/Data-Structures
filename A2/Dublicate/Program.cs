using System;

namespace Dublicate
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "HTMMTMMHTMMTMM";
            Console.WriteLine(IsDublicate(s));
        }

        private static bool IsDublicate(string s)
        {
            if(s == "")
                return true;
            int n = s.Length;
            if(n%2 != 0 || s.Substring(0, (int)n/2) != s.Substring((int)n/2, n - (int)n/2))
                return false;
            return IsDublicate(s.Substring(1, (int)n/2 - 1));
        }
    }
}
