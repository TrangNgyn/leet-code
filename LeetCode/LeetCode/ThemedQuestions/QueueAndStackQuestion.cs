using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace LeetCode.ThemedQuestions
{
    public class QueueAndStackQuestion
    {
        /*
         * 20. Valid Parentheses
         * Problem: https://leetcode.com/problems/valid-parentheses/description/
         * 
         * Time complexity: O(n)
         * Space complexity: O(n)
         */
        public static bool IsValidParentheses(string s)
        {
            var parenPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
            var openingParens = new Stack<char>();

            foreach (char p in s)
            {
                if(parenPairs.Keys.Contains(p))
                {
                    openingParens.Push(p);
                }
                else
                {
                    if(openingParens.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        var prev = openingParens.Pop();
                        if (parenPairs[prev] != p)
                        {
                            return false;
                        }
                    }                    
                }
            }
            return openingParens.Count == 0;
        }
    }

    /*
     * 155. Min Stack
     * Problkem: https://leetcode.com/problems/min-stack/description/
     */
    public class MinStack
    {
        private int currMin = int.MaxValue;
        private Stack<int[]> stack = new Stack<int[]>(); // stack of val-min pair where pair[1] is the min val in the stack when pair[0] is at the top
        public MinStack()
        {

        }

        public void Push(int val)
        {
            currMin = Math.Min(val, currMin);
            var valMinPair = new int[] { val, currMin };
            stack.Push(valMinPair);
        }

        public void Pop()
        {
            stack.Pop();

            if(stack.Count == 0)
            {
                currMin = int.MaxValue;
            }
            else
            {
                currMin = stack.Peek()[1];
            }
        }

        public int Top()
        {
            return stack.Peek()[0];
        }

        public int GetMin()
        {
            return stack.Peek()[1];
        }
    }

    /*
     * 346. Moving Average from Data Stream
     * Problem: https://leetcode.com/problems/moving-average-from-data-stream/description/
     * 
     * Time complexity: O(1)
     * Space complexity: O(n) where n is size of queue
     */
    public class MovingAverage
    {
        private int maxSize;
        private Queue<int> nums;
        private double windowSum;

        public MovingAverage(int size)
        {
            nums = new Queue<int>(size);
            maxSize = size;
            windowSum = 0;
        }

        public double Next(int val)
        {
            if(nums.Count == maxSize)
            {
                var head = nums.Dequeue();
                windowSum -= head;
            }
            nums.Enqueue(val);
            windowSum += val;

            return Math.Round(windowSum/nums.Count, 5);
        }
    }

    /*
     * Design Circular Queue
     * Problem: https://leetcode.com/problems/design-circular-queue/description/
     */
    public class MyCircularQueue
    {
        private int[] queue;
        private int head, count, queueSize;

        public MyCircularQueue(int k)
        {
            queue = new int[k];
            head = count = 0;
            queueSize = k;
        }

        public bool EnQueue(int value)
        {
            if (IsFull())
                return false;

            queue[(head + count) % queueSize] = value;
            count += 1;
            return true;
        }

        public bool DeQueue()
        {
            if(IsEmpty()) return false;

            head = (head + 1) % queueSize;
            count -= 1;
            return true;
        }

        public int Front()
        {
            if(IsEmpty())
            {
                return -1;
            }

            return queue[head];
        }

        public int Rear()
        {
            if (IsEmpty())
            {
                return -1;
            }

            var tail = (head + count - 1) % queueSize;
            return queue[tail];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public bool IsFull()
        {
            return count == queueSize;
        }
    }
}
