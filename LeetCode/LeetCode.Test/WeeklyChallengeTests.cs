using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Test
{
    class WeeklyChallengeTests
    {
        /**** Week 1: 25/06/2023 ****/
        [Test]
        [TestCase(new int[] { 2, 5, 1, 4 }, 5)]
        [TestCase(new int[] { 11, 21, 12 }, 2)]
        public void CountBeautifulPairsTests(int[] nums, int expected)
        {
            int result = WeeklyChallenge.CountBeautifulPairs(nums);

            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new int[] { 0, 1, 0, 0, 1 }, 3)]
        [TestCase(new int[] { 0, 1, 0 }, 1)]
        [TestCase(new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 }, 12)]
        [TestCase(new int[] { 0, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1 }, 36)]
        [TestCase(new int[] { 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0}, 230630552)]
        public void NumberOfGoodSubarraySplitsTests(int[] nums, int expected)
        {
            int result = WeeklyChallenge.NumberOfGoodSubarraySplits(nums);

            result.Should().Be(expected);
        }

        /**** Week 2: 02/07/2023 ****/
        [Test]
        [TestCase(new int[] { 3, 2, 5, 4 }, 5, 3)]
        [TestCase(new int[] { 1, 2 }, 2, 1)]
        [TestCase(new int[] { 2, 3, 4, 5 }, 4, 3)]
        [TestCase(new int[] { 4 }, 1, 0)]
        [TestCase(new int[] { 1, 6 }, 2, 0)]
        public void LongestAlternatingSubarrayTests(int[] nums, int threshold, int expected)
        {
            int result = WeeklyChallenge.LongestAlternatingSubarray(nums, threshold);

            result.Should().Be(expected);
        }

        
        public void FindPrimePairsTests(int n, int[] expected)
        {
            var result = WeeklyChallenge.FindPrimePairs(n);

            result.Count.Should().Be(expected.Length);

            if (expected.Length > 0)
                result.Should().Contain(expected);
        }

        [Test]
        [TestCase(new int[] { 5, 4, 2, 4 }, 8)]
        [TestCase(new int[] { 1, 2, 3 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 10 }, 6)]
        public void ContinuousSubarraysTests(int[] nums, long expected)
        {
            var result = WeeklyChallenge.ContinuousSubarrays(nums);

            result.Should().Be(expected);
        }

    }
}
