using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeetCode.ThemedQuestions
{
    public class QueueAndStackQuestion
    {

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
