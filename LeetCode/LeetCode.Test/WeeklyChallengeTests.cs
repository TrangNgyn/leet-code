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

        /**** Week 1: 25/06/2023 ****/

    }
}
