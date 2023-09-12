using System;

namespace C4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1,2,5,4,6,8};
            System.Console.WriteLine(Min(nums, 0, nums.Length - 1));
        }
        public static int Min(int[] nums, int left, int right)
        {
            if(left == right)
                return nums[right];
            int mid = (left + right + 1)/2;
            int LMin = Min(nums, left, mid - 1);
            int RMin = Min(nums, mid, right);
            return Min(nums, LMin, RMin);
        }
    }
}
