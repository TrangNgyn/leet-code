using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Test
{
    public class DailyChallengeTests
    {
        [Test]
        [TestCase("ab", "ba", true)]
        [TestCase("ab", "aa", false)]
        [TestCase("aa", "aa", true)]
        [TestCase("abcd", "badc", false)]
        [TestCase("abab", "baba", false)]
        [TestCase("aaab", "aaab", true)]
        public void BuddyStringsTests(string s, string goal, bool expected)
        {
            var result = DailyChallenge.BuddyStrings(s, goal);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new int[] { 1, 1, 0, 1 }, 3)]
        [TestCase(new int[] { 1, 1, 1 }, 2)]
        [TestCase(new int[] { 0, 1, 1, 1, 0, 1, 1, 0, 1 }, 5)]
        [TestCase(new int[] { 1, 1, 0, 0, 0, 1 }, 2)]
        [TestCase(new int[] { 0, 0, 0 }, 0)]
        public void LongestSubarrayTests(int[] nums, int expected)
        {
            var result = DailyChallenge.LongestSubarray(nums);
            result.Should().Be(expected);
        }
    }
}
