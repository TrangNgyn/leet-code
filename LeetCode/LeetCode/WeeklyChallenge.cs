using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    public class WeeklyChallenge
    {
        /**** Week 1: 25/06/2023 ****/

        /*
         * Number of Beautiful Pairs
         * Problem: https://leetcode.com/problems/number-of-beautiful-pairs/
         */
        public static int CountBeautifulPairs(int[] nums)
        {
            var count = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var a = FirstDigit(nums[i]);
                    var b = LastDigit(nums[j]);
                    if (IsBeautifulPair(a, b))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static bool IsBeautifulPair(int a, int b)
        {
            return BigInteger.GreatestCommonDivisor(a, b) == 1;
        }

        public static int FirstDigit(int num)
        {
            return (int)(num.ToString()[0]) - 48;
        }

        public static int LastDigit(int num)
        {
            return num % 10;
        }

        /*
         * Problem description: https://leetcode.com/problems/ways-to-split-array-into-good-subarrays/description/
         * 
         * The number of good subarray = Product(number of 0s between 2 immediate ones + 1)
         * Leading zeros and ending zeros don't count
         * 
         * Time complexity: O(n)
         * Space complexity: O(1)
         */
        public static int NumberOfGoodSubarraySplits(int[] nums)
        {
            const int mod = 1000000007;

            if (nums.Sum() == 0) // there is no 1
            {
                return 0;
            }
            else if (nums.Sum() == 1) // there is only 1
            {
                return 1;
            }
            else
            {
                long ways = 1;
                int prevOne = Array.IndexOf(nums, 1); // get index of first 1 O(n) complexity

                for (int i = prevOne + 1; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                    {
                        int nextOne = i;

                        long dist = nextOne - prevOne;
                        ways *= dist;
                        ways %= mod;

                        prevOne = nextOne;
                    }
                }

                return (int)ways;
            }

        }

        /**** Week 2: 02/07/2023 ****/


    }
}
