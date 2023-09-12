using System.Collections.Generic;

namespace C8
{
    class DisjointSets
    {
        int[] parent;
        int n;
        public DisjointSets(int n)
        {
            parent = new int[n];
           makeSet();
        }

        public void makeSet()
        {
            for (int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int find(int x)
        {
            if(parent[x] != x)
                parent[x] = find(parent[x]);
            return parent[x];
        }

        public void union(int x, int y)
        {
            int xRoot = find(x);
            int yRoot = find(y);
            int a = xRoot < yRoot? parent[yRoot] = xRoot: xRoot > yRoot? parent[xRoot] = yRoot: 0;
        }
    }
}
