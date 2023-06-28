using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.Test
{
    public class HashTableQuestionTests
    {
        [Theory]
        public void DesignHashSetTests()
        {
            var myHashSet = new MyHashSet(); // set = []

            myHashSet.Contains(3).Should().BeFalse();

            myHashSet.Add(1);      // set = [1]
            myHashSet.Add(2);      // set = [1, 2]
            myHashSet.Contains(1).Should().BeTrue();
            myHashSet.Contains(3).Should().BeFalse();

            myHashSet.Add(2);      // set = [1, 2]
            myHashSet.Contains(2).Should().BeTrue();

            myHashSet.Remove(2);   // set = [1]
            myHashSet.Contains(2).Should().BeFalse(); // already removed

            myHashSet.Remove(3);   // set = [1]
            myHashSet.Contains(1).Should().BeTrue();

            myHashSet.Remove(1);   // set = []
            myHashSet.Contains(1).Should().BeFalse(); // already removed

            myHashSet.Remove(1);   // set = []
            myHashSet.Contains(1).Should().BeFalse(); // already removed

            myHashSet.Add(1);      // set = [1]
            myHashSet.Add(2000);      // set = [1, 2000]
            myHashSet.Contains(2000).Should().BeTrue();

            myHashSet.Add(0);      // set = [1,2000,0]
            myHashSet.Add(10 ^ 6);      // set = [1, 2000, 0, 10^6]
            myHashSet.Contains(0).Should().BeTrue();
            myHashSet.Contains(10 ^ 6).Should().BeTrue();

            myHashSet.Add(1001);      // set = [1, 2000, 0, 10^6, 1001]
            myHashSet.Contains(1001).Should().BeTrue();
        }

        [Theory]
        public void DesignHashSetTests2()
        {
            var myHashSet = new MyHashSet(); // set = []

            myHashSet.Add(33003);       // [33003]
            myHashSet.Contains(33003).Should().BeTrue();  // true

            myHashSet.Add(43907);       // [33003, 43907]
            myHashSet.Add(32233);       // [33003, 43907, 32233]
            myHashSet.Add(58636);       // [33003, 43907, 32233, 58636]
            myHashSet.Add(66409);       // [33003, 43907, 32233, 58636, 66409]
            myHashSet.Remove(27702);    // [33003, 43907, 32233, 58636, 66409]

            myHashSet.Add(80882);       // [33003, 43907, 32233, 58636, 66409, 80882]
            myHashSet.Remove(12563);    // [33003, 43907, 32233, 58636, 66409, 80882]
            myHashSet.Contains(75034).Should().BeFalse();  // false

            myHashSet.Add(32143);       // [33003, 43907, 32233, 58636, 66409, 80882, 32143]
            myHashSet.Remove(1111);     // [33003, 43907, 32233, 58636, 66409, 80882, 32143]
            myHashSet.Contains(61699).Should().BeFalse();  // false
        }

        [Theory]
        public void DesignHashMapTests()
        {
            MyHashMap myHashMap = new MyHashMap();
            myHashMap.Put(1, 1); // The map is now [[1,1]]
            myHashMap.Put(2, 2); // The map is now [[1,1], [2,2]]
            myHashMap.Get(1).Should().Be(1);    // return 1, The map is now [[1,1], [2,2]]
            myHashMap.Get(3).Should().Be(-1);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
            myHashMap.Put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
            myHashMap.Get(2).Should().Be(1);    // return 1, The map is now [[1,1], [2,1]]
            myHashMap.Remove(2); // remove the mapping for 2, The map is now [[1,1]]
            myHashMap.Get(2).Should().Be(-1);    // return -1 (i.e., not found), The map is now [[1,1]]
        }

        [Test]
        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2, 2 }, 1)]
        [TestCase(new int[] { 2, 1, 2 }, 1)]
        [TestCase(new int[] { 2, 2, 1 }, 1)]
        public void SingleNumberTests(int[] nums, int expected)
        {
            // arrange
            var result = HashTableQuestion.SingleNumber(nums);

            // assert
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 1, 3 }, new int[] { 1, 5, 8 }, new int[] { 1 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 9, 8 }, new int[] { })]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 }, new int[] { 1 })]
        public void IntersectionTests(int[] nums1, int[] nums2, int[] expected)
        {
            // arrange
            var result = HashTableQuestion.Intersection(nums1, nums2);

            // assert
            result.Length.Should().Be(expected.Length);

            if (expected.Length > 0)
                result.Should().Contain(expected);
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(7, true)]
        [TestCase(19, true)]
        [TestCase(999, false)]
        [TestCase(1009, true)]
        public void IsHappyNumberTests(int num, bool expected)
        {
            // arrange
            var result = HashTableQuestion.IsHappy(num);

            // assert
            result.Should().Be(expected);
        }
    }
}
