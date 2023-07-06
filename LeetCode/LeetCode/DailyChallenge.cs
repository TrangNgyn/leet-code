using System;
using System.Collections.Generic;
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

        /*
         * Buddy String
         * Problem: https://leetcode.com/problems/buddy-strings/description/
         * 
         * Time complexity: O(n)
         * Space complexity: O(1) (worst case: 26 characters in the alphabet)
         */
        public static bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length || s.Length == 1)
            {
                return false;
            }

            var charSet = new HashSet<char>();
            var charMap = new List<char>();
            var diffCharcount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    diffCharcount++;
                    if (diffCharcount > 2)
                    {
                        return false;
                    }

                    charMap.Add(s[i]);
                    charMap.Add(goal[i]);
                }                

                charSet.Add(s[i]);
            }

            if (diffCharcount == 1)
            {
                return false;
            }
            else if (diffCharcount == 2)
            {
                if (charMap[0] != charMap[3] || charMap[1] != charMap[2])
                {
                    return false;
                }
            }

            var containsDuplicates = charSet.Count < s.Length;
            if (!containsDuplicates && s == goal)
            {
                return false;
            }

            return true;
        }

        /*
         * Longest Subarray of 1's After Deleting One Element
         * Problem: https://leetcode.com/problems/longest-subarray-of-1s-after-deleting-one-element/description/
         * Use sliding window
         * Time complexity: O(n)
         * Space complexity: O(1)
         */
        public static int LongestSubarray(int[] nums)
        {
            var zeroCount = 0; // number of 0s in the sliding window
            var maxWindowSize = 0;
            var left = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > 1)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }

                    left++;
                }

                maxWindowSize = Math.Max(maxWindowSize, i - left);
            }

            return maxWindowSize;
        }

        /*
         * Minimum Size Subarray Sum
         * Problem: https://leetcode.com/problems/minimum-size-subarray-sum/
         * 
         * Use sliding window
         * Time complexity: O(n)
         * Space complexity: O(1)
         */
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int minLen = int.MaxValue, start = 0, end = 0, sum = 0;

            while(end < nums.Length)
            {
                sum += nums[end];

                while(sum >= target)
                {
                    minLen = Math.Min(minLen, end - start + 1);
                    sum -= nums[start];
                    start++;
                }
                end++;
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }
    }
}
