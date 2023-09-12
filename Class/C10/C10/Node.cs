using System;

namespace C10
{
    public class Node : IComparable<Node>
    {
        public int freq;
        public char chr;
        public Node left = null;
        public Node right = null;
        public Node(char c, int f)
        {
            freq = f;
            chr = c;
        }

        public int CompareTo(Node other)
        {
            return this.freq != other.freq? 
            this.freq.CompareTo(other.freq): 
            this.chr.CompareTo(other.chr);
        }
    }
}
