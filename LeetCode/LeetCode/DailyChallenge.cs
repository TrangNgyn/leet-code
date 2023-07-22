using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Text;
using LeetCode.SharedModels;

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

        /*
         * Maximize the Confusion of an Exam
         * Problem: https://leetcode.com/problems/maximize-the-confusion-of-an-exam/description/
         * 
         * Use sliding window:
         *  - Time complexity: O(2n) = O(n)
         *  - Space complexity: O(1)
         */
        public static int MaxConsecutiveAnswers(string answerKey, int k)
        {
            int maxLen = 0, left = 0, replacedAns = 0;

            for (int i = 0; i < answerKey.Length; i++)
            {
                if (answerKey[i] != 'T')
                {
                    replacedAns++;
                }

                while(replacedAns > k)
                {
                    if (answerKey[left] != 'T')
                    {
                        replacedAns--;
                    }                    
                    left++;
                }

                maxLen = Math.Max(maxLen, i - left + 1);
            }

            left = 0;
            replacedAns = 0;
            for (int i = 0; i < answerKey.Length; i++)
            {
                if (answerKey[i] != 'F')
                {
                    replacedAns++;
                }

                while (replacedAns > k)
                {
                    if (answerKey[left] != 'F')
                    {
                        replacedAns--;
                    }
                    left++;
                }

                maxLen = Math.Max(maxLen, i - left + 1);
            }

            return maxLen;
        }

        /*
         * Put marbles in bags
         * Problem: https://leetcode.com/problems/put-marbles-in-bags/
         * 
         * Observations:
         *  - For k bags, there are always k-1 splitting points
         *  - The score of a marble distribution = 
         *      (weight[0] + weight[last]) + sum(weights between 2 consecutive ends of the sub-arrays)
         *  - Max(score) occurs when max(sum(k-1 weights between 2 consecutive ends of the sub-arrays))
         *  - Min(score) occurs when min(sum(k-1 weights between 2 consecutive ends of the sub-arrays))
         *  
         *  Time complexity: O(n + sorting algo complexity)
         *  Space complexity: O(n - 1) = O(n)
         */
        public static long PutMarbles(int[] weights, int k)
        {
            var pairWeight = new List<long>();

            for(int i = 0; i < weights.Length - 1; i++)
            {
                pairWeight.Add((long) weights[i] + weights[i+1]);
            }

            var sorted = pairWeight.OrderByDescending(x => x);
            var maxScore = sorted.Take(k - 1).Sum();
            var minScore = sorted.TakeLast(k - 1).Sum();

            return maxScore - minScore;
        }

        /*
         * Minimum depth of Binary tree
         * Proiblem: https://leetcode.com/problems/minimum-depth-of-binary-tree/description/
         * 
         * Use Depth first search
         * Time complexity: O(n)
         * Space complexity: O(n)
         */
        public static int MinDepth(TreeNode root)
        {
            return DFS(root);
        }

        private static int DFS(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            // one of the child is not null
            if (root.Left == null)
            {
                return 1 + DFS(root.Right);
            }
            else if (root.Right == null)
            {
                return 1 + DFS(root.Left);
            }

            return 1 + Math.Min(DFS(root.Right), DFS(root.Left));
        }

        /*
         * 11. Container With Most Water
         * Problem: https://leetcode.com/problems/container-with-most-water/description/
         * 
         * Sliding window with 2 pointers
         * Time complexity: O(n)
         * Space complexity: O(1)
         */
        public static int MaxArea(int[] height)
        {
            var left = 0;
            var right = height.Length - 1;
            var area = 0;
            
            while(right > left && left < height.Length - 1)
            {   
                var h = Math.Min(height[left], height[right]);
                area = Math.Max(area, h * (right - left));

                if(height[right] < height[left])
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return area;
        }

        /*
         * 445. Add Two Numbers II
         * Problem: https://leetcode.com/problems/add-two-numbers-ii/
         * 
         * Time complexity: O(n + m)
         * Space complexity: O(1)
         */
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            BigInteger num1 = 0;
            while(l1 != null)
            {
                num1 = num1* 10 + l1.Val;
                l1 = l1.Next;
            }

            BigInteger num2 = 0;
            while (l2 != null)
            {
                num2 = num2 * 10 + l2.Val;
                l2 = l2.Next;
            }

            BigInteger sum = num1 + num2;
            ListNode temp = null, node = null;

            if(sum == 0)
            {
                return new ListNode(0);
            }

            while(sum > 0)
            {
                BigInteger val = sum % 10;
                node = new ListNode()
                {
                    Val = (int) val,
                    Next = temp,
                };

                temp = node;
                sum = (sum - val)/10;
            }

            return node;
        }

        /*
         * 735. Asteroid Collision
         * Problem: https://leetcode.com/problems/asteroid-collision/description/
         */
        public static int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();

            for(int i = 0; i < asteroids.Length; i++)
            {
                bool flag = true;
                while (stack.Count > 0 && (stack.Peek() > 0 && asteroids[i] < 0))
                {
                    // If the top asteroid in the stack is smaller, then it will explode.
                    // Hence pop it from the stack, also continue with the next asteroid in the stack.
                    if (Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                        continue;
                    }
                    // If both asteroids have the same size, then both asteroids will explode.
                    // Pop the asteroid from the stack; also, we won't push the current asteroid to the stack.
                    else if (Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                    }

                    // If we reach here, the current asteroid will be destroyed
                    // Hence, we should not add it to the stack
                    flag = false;
                    break;
                }

                if (flag)
                {
                    stack.Push(asteroids[i]);
                }
            }

            return stack.ToArray();
        }

    }
}
