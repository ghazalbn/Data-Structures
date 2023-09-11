using System;

namespace Queens
{
	class Program
	{
		public static void Main (string[] args)
		{
			Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
			Enumerate(n);
		}

		public static void printBoard(int[] q) {

			int n = q.Length;
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					if (q[i] == j)
						Console.Write("Q ");
					else
						Console.Write("- ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
		
		public static void Enumerate(int n) {
			int[] a = new int[n];
			Enum(a, 0);
		}

		public static void Enum(int[] q, int k) {

			int n = q.Length;
			if (k == n)
			{
				printBoard(q);
				Console.ReadKey();
			}
			else {
				for (int i = 0; i < n; i++) {
					q[k] = i;
					if (IsConsistent(q, k))
						Enum(q, k + 1);
				}
			}
		}
		public static bool IsConsistent(int[] a, int n) {
			for (int i = 0; i < n; i++) {
				if (a[i] == a[n] || a[i] - a[n] == n - i || a[n] - a[i] == n - i)
					return false;
			}
			return true;
		}
	}
}
