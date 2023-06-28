using NUnit.Framework;
using FluentAssertions;

namespace LeetCode.Test
{
    public class BeginnerQuestionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
        [TestCase(new int[] { 2, 4 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 5 })]
        [TestCase(new int[] { 5, 6, 4 }, new int[] { 2, 4 }, new int[] { 7, 0, 5 })]
        public void AddTwoNumbersTests(int[] num1, int[] num2, int[] sum)
        {
            // arrange
            var l1 = new ListNode(num1);
            var l2 = new ListNode(num2);
            var expected = new ListNode(sum);

            // act
            var result = BeginnerQuestion.AddTwoNumbers(l1, l2);

            // assert
            result.Should().BeEquivalentTo(expected);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3 }, 4, 7)]
        [TestCase(new int[] { 9 }, 3, 0)]
        public void CombinationSum4Tests(int[] nums, int target, int expected)
        {
            // arrange

            // act
            var result = BeginnerQuestion.CombinationSum4(nums, target);

            // assert
            result.Should().Equals(expected);
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] {3, 4, 5})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6 })]
        public void MiddleNodeOfLinkedListTests(int[] inputList, int[] expected)
        {
            // arrange
            var list = new ListNode(inputList);

            // act
            var result = BeginnerQuestion.MiddleNode(list);

            // assert
            var resultArray = result.ToArray();
            resultArray.Should().BeEquivalentTo(expected);
            
        }

        [Test]
        [TestCase("aa", "a", false)]
        [TestCase("aa", "ab", false)]
        [TestCase("ab", "a", false)]
        [TestCase("ab", "aab", true)]

        public void RansomNoteTests(string ransomNote, string magazine, bool expected)
        {
            // arrange

            // act
            var result = BeginnerQuestion.CanConstruct(ransomNote, magazine);

            // assert
            result.Should().Be(expected);
        }
    }
}