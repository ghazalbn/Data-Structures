using System;

namespace perm
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = new char[]{'m', 'i', 'n', 'a'};
            perm(s, 0, s.Length);
        }
        public static void perm (char[] s,int n,int N)
        {

            if(n==N)
                Console.WriteLine(s);

            else
            {
                char x=s[n];
                int i;
                for(i = n; i < N; i++)
                {
                    s[n]=s[i];
                    s[i]=x;
                    perm(s, n + 1, N);
                    s[i]=s[n];
                }
                s[n]=x;
            }
        }
    }
}
