using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    public class DailyChallenge
    {

        /*
         * Problem description: https://leetcode.com/problems/tallest-billboard/
         * Problem reworded: Find 2 subsets of an array that have the same sum of its elements 
         *  so that the sum is the largest possible
         *  sum(all-elements) = 2 x maxSum(subset) + sum(left-overs)
         *  sum(all-elements) - sum(left-overs) must be even
         *  if sum(all-elements) is even, then sum(left-overs) is even
         *  if sum(all-elements) is odd, then sum(left-overs) is odd
         */
        public static int TallestBillboard(int[] rods)
        {
            var sumAllRods = rods.Sum();



            if (sumAllRods % 2 == 0)
            {

            }
            else
            {

            }

            return sumAllRods;
        }
    }
}
