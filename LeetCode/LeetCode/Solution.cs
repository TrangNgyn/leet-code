using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public static class Solution
    {
        /*
        *  Problem description: https://leetcode.com/problems/add-two-numbers/solution/
        *  Solution:
        *   - Traverse each list and add each node one by one
        *   - Don't forget about the carry             *
        */
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode current = new ListNode(0);
            ListNode result = current;
            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int val1 = l1 != null ? l1.val : 0;
                int val2 = l2 != null ? l2.val : 0;
                int sum = val1 + val2 + carry;
                carry = sum/10;

                current.next = new ListNode(sum%10);
                
                // traversing the lists
                current = current.next;
                l1 = l1?.next ?? null;
                l2 = l2?.next ?? null;

            }

            return result.next;
        }


        /*
        *  Problem description: https://leetcode.com/problems/combination-sum-iv/
        *  Breaking down the problem:
        *   - Combinations of numbers that sum up to the target (positions doesn't matter)
        *   - Count the number of possible sequences by switching the numbers around the numbers in the combinations above
        *   - Edge cases:
        *      - array contains n where target < n -> no combination containing n
        *      - input array contains n where target % n == 0 -> at least 1 combination containing all n
        *   - target can be represented as a*x + b = target
        *  
        */
        public static int CombinationSum4(int[] nums, int target)
        {
            return 0;
        }


        /*
         *  Problem description: https://leetcode.com/problems/middle-of-the-linked-list/ 
         *  Time complexity: O(n)
         *  Space complexity: O(n)
         */
        public static ListNode MiddleNode(ListNode head)
        {
            IList<ListNode> nodes = new List<ListNode>();
            var current = head;

            while (current != null)
            {
                nodes.Add(current);
                current = current.next;
            }

            int midIndex = Convert.ToInt32(Math.Floor((decimal)(nodes.Count) / 2));

            return nodes[midIndex];
        }

        /*
         *  Problem description: https://leetcode.com/problems/ransom-note/
         *  Breaking down the problem:
         *   - magazine is a pool of characters for the ransom note (each letter is only used once)
         *   - magaizen can have letters that are not required by the ransom note
         *   - Time complexity: O(m + n)
         *   - Space complexity: O(m)
         */
        public static bool CanConstruct(string ransomNote, string magazine)
        {
            // create a hash map that counts each letter in the magazine
            var letterPool = new Dictionary<char, int>();
            foreach(var letter in magazine)
            {
                if (!letterPool.ContainsKey(letter))
                {
                    letterPool.Add(letter, 1);
                }
                else
                {
                    letterPool[letter] += 1;
                }
            }

            // check if the letter pool contains the chars needed for the ransom note
            foreach(var letter in ransomNote)
            {
                if (!letterPool.ContainsKey(letter))
                {
                    return false;
                }
                else
                {
                    letterPool[letter] -= 1;
                }

                if (letterPool[letter] < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
