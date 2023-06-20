using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(params int[] numbers)
        {
            var dummyHead = new ListNode(0);
            var head = dummyHead;

            foreach(int n in numbers)
            {
                dummyHead.next = new ListNode(n);
                dummyHead = dummyHead.next;
            }

            this.val = head.next?.val ?? 0;
            this.next = head.next?.next;
        }

        public int[] ToArray()
        {
            var vals = new List<int>();
            var ptr = this;

            while(ptr != null)
            {
                vals.Add(ptr.val);
                ptr = ptr.next;
            }

            return vals.ToArray();
        }
    }
}
