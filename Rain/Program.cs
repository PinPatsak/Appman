using System;

namespace Rain
{
    class Program
    {
         static int[] arr = new int[] { 0, 3, 1, 3, 0, 4, 1, 2, 4, 1 };
        // static int[] arr = new int[] { 1, 4, 2, 1, 2, 0, 0, 3, 1, 4 };
        // static int[] arr = new int[] { 3, 0, 2, 1, 4, 1, 2, 3, 0, 1 };
        // static int[] arr = new int[] { 0, 3, 3, 3, 1, 3, 1, 1, 1, 4 };
        static int HoldingWater(int n)
        {
            int[] left = new int[n];
            int[] right = new int[n];

            int water = 0;

            left[0] = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] != 0)
                {
                    left[i] = Math.Max(left[i - 1], arr[i]);
                }
                else
                {
                    left[i] = 0;
                }
               
            }
               


            right[n - 1] = arr[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    right[i] = Math.Max(right[i + 1], arr[i]);
                }
                else
                {
                    left[i] = 0;
                }

            }
            
 
            for (int i = 0; i < n; i++)
                water += Math.Min(left[i], right[i]) - arr[i];

            return water;
        }


        public static void Main()
        {

            Console.WriteLine("A maximum number of blocks that can hold the rain " +
                              HoldingWater(arr.Length));
        }
    }
}
