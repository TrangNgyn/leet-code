using NUnit.Framework;
using FluentAssertions;
using LeetCode.ThemedQuestions;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Test.ThemedQuestions
{
    public class QueueAndStackTests
    {
        [Theory]
        public void MyCircularQueueTests()
        {
            MyCircularQueue myCircularQueue1 = new MyCircularQueue(3);
            myCircularQueue1.EnQueue(1).Should().Be(true); // return True
            myCircularQueue1.EnQueue(2).Should().Be(true); // return True
            myCircularQueue1.EnQueue(3).Should().Be(true); // return True
            myCircularQueue1.EnQueue(4).Should().Be(false); // return False
            myCircularQueue1.Rear().Should().Be(3);     // return 3
            myCircularQueue1.IsFull().Should().Be(true);   // return True
            myCircularQueue1.DeQueue().Should().Be(true);  // return True
            myCircularQueue1.EnQueue(4).Should().Be(true); // return True
            myCircularQueue1.Rear().Should().Be(4);     // return 4


            MyCircularQueue myCircularQueue2 = new MyCircularQueue(6);
            myCircularQueue2.EnQueue(6).Should().Be(true);
            myCircularQueue2.Rear().Should().Be(6);
            myCircularQueue2.Rear().Should().Be(6);
            myCircularQueue2.DeQueue().Should().Be(true);
            myCircularQueue2.EnQueue(5).Should().Be(true);
            myCircularQueue2.Rear().Should().Be(5);
            myCircularQueue2.DeQueue().Should().Be(true);
            myCircularQueue2.Front().Should().Be(-1);
            myCircularQueue2.DeQueue().Should().Be(false);
            myCircularQueue2.DeQueue().Should().Be(false);
            myCircularQueue2.DeQueue().Should().Be(false);
        }
    }
}
