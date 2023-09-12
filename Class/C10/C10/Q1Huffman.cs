using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Diagnostics.CodeAnalysis;
using Priority_Queue;

namespace C10
{
    public class Q1Huffman : Processor
    {
        public Q1Huffman(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string,string>)Solve);

        public Dictionary<char, int> GenerateDict(string s)
        {
            Dictionary<char, int> f = new Dictionary<char, int>();
            foreach (char c in s)
                f[c] = f.GetValueOrDefault(c, 0) + 1;
            return f;

        }

        public string Solve(string s)
        {
            Dictionary<char, int> leave = GenerateDict(s);
            var nodes = new SimplePriorityQueue<Node, Node>();
            foreach (var leaf in leave.Keys)
            {
                Node n = new Node(leaf, leave[leaf]);
                nodes.Enqueue(n, n);
            }
            while (nodes.Count > 1)
            {
                (var node1, var node2) = (nodes.Dequeue(), nodes.Dequeue());
                Node parent = new Node('$', node1.freq + node2.freq);
                (parent.left, parent.right) = (node1, node2);
                nodes.Enqueue(parent, parent);
            }
            var codeWords = new Dictionary<char, string>();
            GenerateCodes(nodes.Dequeue(), "", codeWords);
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
                sb.Append(codeWords[c]);
            return sb.ToString();
        }

        private void GenerateCodes(Node node, string v, Dictionary<char, string> codeWords)
        {
            if (node == null) return;
            if (node.chr == '$')
            {
                GenerateCodes(node.left, v + '0', codeWords);
                GenerateCodes(node.right, v + '1', codeWords);
            }
            else
                codeWords.Add(node.chr, v);
            
        }
    }
}
