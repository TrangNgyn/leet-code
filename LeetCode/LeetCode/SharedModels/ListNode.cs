using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.SharedModels
{
    public class ListNode
    {
        public int Val { get; set; }
        public ListNode Next { get; set; }

        public ListNode(int val = 0, ListNode next = null)
        {
            Val = val;
            Next = next;
        }

        public ListNode(params int[] numbers)
        {
            var dummyHead = new ListNode(0);
            var head = dummyHead;

            foreach (int n in numbers)
            {
                dummyHead.Next = new ListNode(n);
                dummyHead = dummyHead.Next;
            }

            Val = head.Next?.Val ?? 0;
            Next = head.Next?.Next;
        }

        public int[] ToArray()
        {
            var vals = new List<int>();
            var ptr = this;

            while (ptr != null)
            {
                vals.Add(ptr.Val);
                ptr = ptr.Next;
            }

            return vals.ToArray();
        }
    }
}
