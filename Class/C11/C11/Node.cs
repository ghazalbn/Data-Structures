using System;

namespace C11
{
    class Node: IComparable
    {
        public long num;
        public long cost;
        public Node parent;
        public Node(long n,long c)
        {
            num = n;
            cost = c;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
