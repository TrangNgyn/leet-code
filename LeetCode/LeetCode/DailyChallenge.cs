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

            var charCount = new Dictionary<char, int>();
            var charMap = new Dictionary<char, char>();
            var diffCharcount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    diffCharcount++;
                    charMap[s[i]] = goal[i];
                }

                if (diffCharcount > 2)
                {
                    return false;
                }

                var count = charCount.TryGetValue(s[i], out var val) ? val : 0;
                charCount[s[i]] = count + 1;
            }

            if (charMap.Keys.Count == 1)
            {
                return false;
            }
            else if (charMap.Keys.Count == 2)
            {
                var sChar1 = charMap.Keys.ToList()[0];
                var sChar2 = charMap.Keys.ToList()[1];
                if (sChar1 != charMap[sChar2] || sChar2 != charMap[sChar1])
                {
                    return false;
                }
            }

            if (!charCount.Values.Any(x => x > 1) && s == goal)
            {
                return false;
            }

            return true;
        }
    }
}
