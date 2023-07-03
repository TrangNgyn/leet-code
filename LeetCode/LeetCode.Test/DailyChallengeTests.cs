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
        public void BuddyStringsTests(string s, string goal, bool expected)
        {
            var result = DailyChallenge.BuddyStrings(s, goal);
            result.Should().Be(expected);
        }
    }
}
