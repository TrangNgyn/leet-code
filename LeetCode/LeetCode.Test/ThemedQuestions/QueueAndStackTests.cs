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

        [Theory]
        public void MovingAverageTests()
        {
            MovingAverage movingAverage = new MovingAverage(3);
            movingAverage.Next(1).Should().Be(1); // return 1.0 = 1 / 1
            movingAverage.Next(10).Should().Be(5.5); // return 5.5 = (1 + 10) / 2
            movingAverage.Next(3).Should().Be(4.66667); // return 4.66667 = (1 + 10 + 3) / 3
            movingAverage.Next(5).Should().Be(6.0); // return 6.0 = (10 + 3 + 5) / 3
        }

        [Theory]
        public void MinStackTests()
        {
            // push new min to stack then pop and get min
            MinStack minStack1 = new MinStack();
            minStack1.Push(-2);
            minStack1.Push(0);
            minStack1.Push(-3);
            minStack1.GetMin().Should().Be(-3); // return -3
            minStack1.Pop();
            minStack1.Top().Should().Be(0);    // return 0
            minStack1.GetMin().Should().Be(-2); // return -2

            // pop until stack is empty then get min
            MinStack minStack2 = new MinStack();
            minStack2.Push(2147483646);
            minStack2.Push(2147483646);
            minStack2.Push(2147483647);
            minStack2.Top().Should().Be(2147483647);
            minStack2.Pop();
            minStack2.GetMin().Should().Be(2147483646);
            minStack2.Pop();
            minStack2.GetMin().Should().Be(2147483646);
            minStack2.Pop();
            minStack2.Push(2147483647);
            minStack2.Top().Should().Be(2147483647);
            minStack2.GetMin().Should().Be(2147483647);
            minStack2.Push(-2147483648);
            minStack2.Top().Should().Be(-2147483648);
            minStack2.GetMin().Should().Be(-2147483648);
            minStack2.Pop();
            minStack2.GetMin().Should().Be(2147483647);

            // 
            MinStack minStack3 = new MinStack();
            minStack3.Push(-10);
            minStack3.Push(14);
            minStack3.GetMin().Should().Be(-10);
            minStack3.GetMin().Should().Be(-10);
            minStack3.Push(-20);
            minStack3.GetMin().Should().Be(-20);
            minStack3.GetMin().Should().Be(-20);
            minStack3.Top().Should().Be(-20);
            minStack3.GetMin().Should().Be(-20);
            minStack3.Pop();
            minStack3.Push(10);
            minStack3.Push(-7);
            minStack3.GetMin().Should().Be(-10);
            minStack3.Push(-7);
            minStack3.Pop();
            minStack3.Top().Should().Be(-7);
            minStack3.GetMin().Should().Be(-10);
            minStack3.Pop();

        }

        [Test]
        [TestCase("()", true)]
        [TestCase("([]){}", true)]
        [TestCase("([)]{}", false)]
        [TestCase("()[]{}", true)]
        [TestCase("(]", false)]
        [TestCase("(", false)]
        [TestCase(")", false)]
        [TestCase("((", false)]
        public void IsValidParenthesesTests(string s, bool expected)
        {
            var res = QueueAndStackQuestion.IsValidParentheses(s);
            res.Should().Be(expected);
        }
    }
}
