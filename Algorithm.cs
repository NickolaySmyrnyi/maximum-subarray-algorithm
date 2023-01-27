using System;
using System.Collections.Generic;
using System.Text;

namespace MaximumSubaray
{
    class Algorithm
    {
        static private Tuple<int, int, int> FindMaxCrossingSubarray(int[] a, int low, int mid, int high)
        {
            var leftSum = int.MinValue;
            int maxLeft = -1;
            for (int i = mid, sum = 0; i >= 0; --i)
            {
                sum += a[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            var rightSum = int.MinValue;
            int maxRight = -1;
            for (int i = mid + 1, sum = 0; i < a.Length; ++i)
            {
                sum += a[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return new Tuple<int, int, int>(maxLeft, maxRight, leftSum + rightSum);
        }

        static public Tuple<int, int, int> FindMaximumSubarray(int[] a, int low, int high)
        {
            if (low == high)
                return new Tuple<int, int, int>(low, high, a[low]);

            var mid = (low + high) / 2;
            var leftMax = FindMaximumSubarray(a, low, mid);
            var rightMax = FindMaximumSubarray(a, mid + 1, high);
            var crossMax = FindMaxCrossingSubarray(a, low, mid, high);

            if (leftMax.Item3 >= rightMax.Item3 && leftMax.Item3 >= crossMax.Item3)
                return leftMax;
            else if (rightMax.Item3 >= leftMax.Item3 && rightMax.Item3 >= crossMax.Item3)
                return rightMax;
            else return crossMax;
        }
    }
}
