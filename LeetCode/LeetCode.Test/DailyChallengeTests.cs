﻿using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
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

        [Test]
        [TestCase(new int[] { 2, 3, 1, 2, 4, 3 }, 7, 2)]
        [TestCase(new int[] { 1, 4, 4 }, 4, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 11, 0)]
        [TestCase(new int[] { 1, 1, 3, 3, 3, 1 }, 2, 1)]
        [TestCase(new int[] { 1, 1, 1 }, 3, 3)]
        public void MinSubArrayLenTests(int[] nums, int target, int expected)
        {
            var result = DailyChallenge.MinSubArrayLen(target, nums);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase("TTFF", 2, 4)]
        [TestCase("TFFT", 1, 3)]
        [TestCase("TTFTTFTT", 1, 5)]
        [TestCase("FTFTTT", 2, 6)]
        [TestCase("F", 1, 1)]
        [TestCase("FFFF", 1, 4)]
        [TestCase("FTFT", 1, 3)]
        public void MaxConsecutiveAnswersTests(string answerKey, int k, int expected)
        {
            var result = DailyChallenge.MaxConsecutiveAnswers(answerKey, k);
            result.Should().Be(expected);
        }

        [Test]
        [TestCase(new int[] { 1, 3, 5, 1 }, 2, 4)]
        [TestCase(new int[] { 5, 1, 0, 2 }, 3, 5)]
        [TestCase(new int[] { 1, 3 }, 2, 0)]        // only 1 distribution
        [TestCase(new int[] { 1, 3, 4 }, 1, 0)]     // k = 1 => only 1 distribution
        [TestCase(new int[] { 1, 3, 4 }, 3, 0)]     // k = weights.Length => only 1 distribution
        public void PutMarblesTests(int[] weights, int k, int expected)
        {
            var result = DailyChallenge.PutMarbles(weights, k);
            result.Should().Be(expected);
        }

        [Theory]
        public void MinTreeDepthTests()
        {
            // Tree 1
            var tree1 = new TreeNode()
            {
                Key = 3,
                Left = new TreeNode(9),
                Right = new TreeNode()
                {
                    Key = 20,
                    Left = new TreeNode(15),
                    Right = new TreeNode(7)
                }
            };

            DailyChallenge.MinDepth(tree1).Should().Be(2);

            // Tree 2
            var tree2 = new TreeNode()
            {
                Key = 2,
                Left = null,
                Right = new TreeNode()
                {
                    Key = 3,
                    Left = null,
                    Right = new TreeNode()
                    {
                        Key = 4,
                        Left = null,
                        Right = new TreeNode()
                        {
                            Key = 5,
                            Left = null,
                            Right = new TreeNode(6)
                        }
                    }
                }
            };

            DailyChallenge.MinDepth(tree2).Should().Be(5);

            // Tree 3
            var tree3 = new TreeNode()
            {
                Key = 1,
                Left = new TreeNode()
                {
                    Key = 2,
                    Left = new TreeNode(4),
                    Right = new TreeNode(5)
                },
                Right = new TreeNode(3)
            };

            DailyChallenge.MinDepth(tree3).Should().Be(2);
        }
    }
}
