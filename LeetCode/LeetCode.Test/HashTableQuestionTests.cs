using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

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

        [Test]
        [TestCase(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 5, 11 })]
        public void TwoSumTests(int[] nums, int target, int[] expected)
        {
            // arrange
            var result = HashTableQuestion.TwoSum(nums, target);

            // assert
            result.Length.Should().Be(expected.Length);

            if (expected.Length > 0)
                result.Should().Contain(expected);
        }

        [Test]
        [TestCase("egg", "add", true)]
        [TestCase("foo", "bar", false)]
        [TestCase("paper", "title", true)]
        [TestCase("a", "b", true)]
        [TestCase("abac", "abab", false)]
        public void IsIsomorphicTests(string s, string t, bool expected)
        {
            // arrange
            var result = HashTableQuestion.IsIsomorphic(s, t);

            // assert
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new string[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" }, new string[] { "Shogun" })]
        [TestCase(new string[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new string[] { "KFC", "Shogun", "Burger King" }, new string[] { "Shogun" })]
        [TestCase(new string[] { "happy", "sad", "good" }, new string[] { "sad", "happy", "good" }, new string[] { "sad", "happy" })]
        public void FindRestaurant(string[] list1, string[] list2, string[] expected)
        {
            // arrange
            var result = HashTableQuestion.FindRestaurant(list1, list2);

            // assert
            result.Length.Should().Be(expected.Length);

            if (expected.Length > 0)
                result.Should().Contain(expected);
        }

        [Test]
        [TestCase("leetcode", 0)]
        [TestCase("loveleetcode", 2)]
        [TestCase("aabb", -1)]
        public void FirstUniqCharTests(string s, int expected)
        {
            // arrange
            var result = HashTableQuestion.FirstUniqChar(s);

            // assert
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new int[] { 1 }, new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 1, 3 }, new int[] { 1, 5, 8 }, new int[] { 1 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 9, 8 }, new int[] { })]
        [TestCase(new int[] { 1, 2, 2, 2 }, new int[] { 1, 2, 2 }, new int[] { 1, 2, 2 })]
        public void IntersectionIITests(int[] nums1, int[] nums2, int[] expected)
        {
            // arrange
            var result = HashTableQuestion.IntersectII(nums1, nums2);

            // assert
            result.Length.Should().Be(expected.Length);

            if (expected.Length > 0)
                result.Should().Contain(expected);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 1 }, 3, true)]
        [TestCase(new int[] { 1, 0, 1, 1 }, 1, true)]
        [TestCase(new int[] { 2, 2 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3, 1, 2, 3 }, 2, false)]
        [TestCase(new int[] { 2 }, 1, false)]
        [TestCase(new int[] { 2, 2 }, 0, false)]
        public void ContainsNearbyDuplicateTests(int[] nums, int k, bool expected)
        {
            // arrange
            var result = HashTableQuestion.ContainsNearbyDuplicate(nums, k);

            // assert
            result.Should().Be(expected);
        }

        [Theory]
        public void LoggerRateLimiterTests()
        {
            // arrange
            var logger = new Logger();
            logger.ShouldPrintMessage(1, "foo").Should().Be(true);  // return true, next allowed timestamp for "foo" is 1 + 10 = 11
            logger.ShouldPrintMessage(2, "bar").Should().Be(true);  // return true, next allowed timestamp for "bar" is 2 + 10 = 12
            logger.ShouldPrintMessage(3, "foo").Should().Be(false);  // 3 < 11, return false
            logger.ShouldPrintMessage(8, "bar").Should().Be(false);  // 8 < 12, return false
            logger.ShouldPrintMessage(10, "foo").Should().Be(false); // 10 < 11, return false
            logger.ShouldPrintMessage(11, "foo").Should().Be(true); // 11 >= 11, return true, next allowed timestamp for "foo" is 11 + 10 = 21
        }

        [Test]
        [TestCase("eat tea tan ate nat bat", "bat, nat tan, ate eat tea")]
        [TestCase("", "")]
        [TestCase("a", "a")]
        public void GroupAnagramsTests(string strs, string expected)
        {
            // arrange
            var input = strs.Split(' ');
            var result = HashTableQuestion.GroupAnagrams(input);

            // assert
            var expectedGroups = expected.Split(", ")
                .Select(x => x.Split(" ").ToList())
                .ToList();

            result.Count.Should().Be(expectedGroups.Count);

            foreach (var group in result)
            {
                var intersect = expectedGroups.First(x => !x.Except(group).Any());
                intersect.Should().NotBeEmpty();
            }
        }

        [Test]
        [TestCase("abc bcd acef xyz az ba a z", "acef, a z, abc bcd xyz, az ba")]
        [TestCase("a", "a")]
        public void GroupStringsTests(string strs, string expected)
        {
            // arrange
            var input = strs.Split(' ');
            var result = HashTableQuestion.GroupStrings(input);

            // assert
            var expectedGroups = expected.Split(", ")
                .Select(x => x.Split(" ").ToList())
                .ToList();

            result.Count.Should().Be(expectedGroups.Count);

            foreach (var group in result)
            {
                var intersect = expectedGroups.First(x => !x.Except(group).Any());
                intersect.Should().NotBeEmpty();
            }
        }
    }
}
