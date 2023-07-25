using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Transactions;

namespace LeetCode
{
    public class WeeklyChallenge
    {
        /**** Week 1: 25/06/2023 ****/

        /*
        * Number of Beautiful Pairs
        * Problem: https://leetcode.com/problems/number-of-beautiful-pairs/
        */
        public static int CountBeautifulPairs(int[] nums)
        {
            var count = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var a = FirstDigit(nums[i]);
                    var b = LastDigit(nums[j]);
                    if (IsBeautifulPair(a, b))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static bool IsBeautifulPair(int a, int b)
        {
            return BigInteger.GreatestCommonDivisor(a, b) == 1;
        }

        public static int FirstDigit(int num)
        {
            return (int)(num.ToString()[0]) - 48;
        }

        public static int LastDigit(int num)
        {
            return num % 10;
        }

        /*
        * Problem description: https://leetcode.com/problems/ways-to-split-array-into-good-subarrays/description/
        * 
        * The number of good subarray = Product(number of 0s between 2 immediate ones + 1)
        * Leading zeros and ending zeros don't count
        * 
        * Time complexity: O(n)
        * Space complexity: O(1)
        */
        public static int NumberOfGoodSubarraySplits(int[] nums)
        {
            const int mod = 1000000007;

            if (nums.Sum() == 0) // there is no 1
            {
                return 0;
            }
            else if (nums.Sum() == 1) // there is only 1
            {
                return 1;
            }
            else
            {
                long ways = 1;
                int prevOne = Array.IndexOf(nums, 1); // get index of first 1 O(n) complexity

                for (int i = prevOne + 1; i < nums.Length; i++)
                {
                    if (nums[i] == 1)
                    {
                        int nextOne = i;

                        long dist = nextOne - prevOne;
                        ways *= dist;
                        ways %= mod;

                        prevOne = nextOne;
                    }
                }

                return (int)ways;
            }

        }

        /**** Week 2: 02/07/2023 ****/
        public static int LongestAlternatingSubarray(int[] nums, int threshold)
        {
            var maxLength = 0;
            var isPreviousEven = false;
            var firstEvenIndex = 0;
            
            // find first even
            for(int i = 0; i < nums.Length; ++i)
            {
                if ((nums[i] % 2 == 0) && (nums[i] <= threshold))
                {
                    firstEvenIndex = i;
                    isPreviousEven = true;
                    maxLength = 1;
                    break;
                }
            }

            if(maxLength == 0) // no starting even number
            {
                return 0;
            }

            var currentLenght = maxLength;

            for(int i = firstEvenIndex + 1; i < nums.Length; ++i)
            {
                if (nums[i] > threshold)
                {
                    currentLenght = 0;
                }

                if(isPreviousEven && nums[i] %2 != 0)
                {
                    currentLenght += 1;
                    isPreviousEven = false;
                }
                else if(!isPreviousEven && nums[i] % 2 == 0)
                {
                    currentLenght += 1;
                    isPreviousEven = true;
                }
                else
                {
                    currentLenght = 0;
                    isPreviousEven = nums[i] % 2 == 0;
                }

                if(currentLenght > maxLength)
                {
                    maxLength = currentLenght;
                }
            }

            return maxLength;
        }



        public static IList<IList<int>> FindPrimePairs(int n)
        {
            var result = new List<IList<int>>();
            for(int i = 2; i <= Math.Floor((float) n/2); i += 2)
            {
                var complement = n - i;
                if(IsPrime(complement) && IsPrime(i))
                {
                    result.Add(new List<int>() { i, complement });
                }
            }

            return result;
        }

        public static bool IsPrime(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0 && i != number) return false;
            }
            return true;
        }





        public static long ContinuousSubarrays(int[] nums)
        {
            var contSubLength = new List<int>();
            var currLength = 0;

            for(int i = 0;  i < nums.Length - 1; i++)
            {
                if (Math.Abs(nums[i+1] - nums[i]) <= 2) {
                    currLength++;
                }
                else
                {
                    contSubLength.Add(currLength + 1);
                    currLength = 0;
                }
            }

            return (long) contSubLength.Sum(n => (n*n + n)/2) + nums.Length;
        }


        public static int TheMaximumAchievableX(int num, int t)
        {
            return 0;
        }

        public static int MaximumJumps(int[] nums, int target)
        {
            var jumpCount = 0;
            int i = 0;
            while(i < nums.Length - 1)
            {
                int j = i + 1;
                while(j < nums.Length)
                {
                    if (Math.Abs(nums[j] - nums[i]) <= target)
                    {
                        jumpCount++;
                        i = j;

                        break;
                    }
                    else
                    {
                        j++;
                    }
                }

                if(j == nums.Length)
                {
                    jumpCount = -1;
                    break;
                }
            }

            return jumpCount;
        }

        public static int MaxNonDecreasingLength(int[] nums1, int[] nums2)
        {
            //var nums3 = new List<int>();
            //for(int i = 0; i < nums1.Length; i++)
            //{
            //    var smaller = Math.Min(nums1[i], nums2[i]);

            //    if(nums3.Count == 0 || nums3[i - 1] <= smaller)
            //    {
            //        nums3.Add(smaller);
            //    }
            //    else if(nums3[i - 1] > smaller && nums3[i - 1] <= nums1[i])
            //    {
            //        nums3.Add(nums1[i]);
            //    }
            //    else if (nums3[i - 1] > smaller && nums3[i - 1] <= nums2[i])
            //    {
            //        nums3.Add(nums2[i]);
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return nums3.Count;

            var nums3 = new List<int>(); // number of 0s in the sliding window
            var maxWindowSize = 0;
            var left = 0;

            for (int i = 0; i < nums1.Length; i++)
            {
                var num = CanAddToNums3(nums1[i], nums2[i], nums3, i);
                if(num != -1)
                {
                    nums3.Add(num);
                }

                while (CanAddToNums3(nums1[i], nums2[i], nums3, i) != -1 && left < nums3.Count)
                {
                    if(left < nums3.Count - 1)
                    {
                        if (nums3[left] > nums3[left + 1])
                        {
                            nums3[left] = -1;
                        }
                    }

                    left++;
                }

                maxWindowSize = Math.Max(maxWindowSize, i - left);
            }

            return maxWindowSize;
        }

        public static int CanAddToNums3(int num1, int num2, IList<int> nums3, int i)
        {
            var smaller = Math.Min(num1, num2);
            
            if (nums3.Count == 0 || i <= 0)
            {
                return smaller;
            }
            else if(nums3[i - 1] <= smaller)
            {
                return smaller;
            }
            else if (nums3[i - 1] > smaller && nums3[i - 1] <= num1)
            {
                return num1;
            }
            else if (nums3[i - 1] > smaller && nums3[i - 1] <= num2)
            {
                return num2;
            }

            return -1;
        }




        /* Week 4: 16-07-2023 */

        public static int SumOfSquares(int[] nums)
        {
            int n = nums.Length;

            int sum = 0;

            for(int i = 0; i < n; i++)
            {
                if (n % (i + 1) == 0)
                {
                    sum += nums[i] * nums[i];
                }
            }

            return sum;
        }



        public static int MaximumBeauty(int[] nums, int k)
        {
            return 0;
        }


        public static int MinimumIndex(IList<int> nums)
        {
            int n = nums.Count;
            Dictionary<int, int> count = new Dictionary<int, int>();
            int domElem = 0, domFreq = 0;

            // Count the occurrences of each element
            foreach (int num in nums)
            {
                if (!count.ContainsKey(num))
                    count[num] = 0;

                count[num]++;
                if (count[num] > domFreq)
                {
                    domElem = num;
                    domFreq = count[num];
                }
            }

            int leftFreq = 0, rightFreq = domFreq;

            // Iterate through the array to find a valid split
            for (int i = 0; i < n - 1; i++)
            {
                if (nums[i] == domElem)
                {
                    leftFreq++;
                    rightFreq--;
                }

                if (leftFreq * 2 > i + 1 && rightFreq * 2 > n - i - 1)
                    return i;
            }

            return -1; // No valid split found
        }

        public static int LongestValidSubstring(string word, IList<string> forbidden)
        {
            return 0;
        }


        /* Week 5: 23-07-2023 */

        public static IList<string> SplitWordsBySeparator(IList<string> words, char separator)
        {
            var res = new List<string>();
            foreach (string word in words)
            {
                res.AddRange(word.Split(separator).Where(x => !string.IsNullOrEmpty(x)));
            }

            return res;
        }


        /*
         * 2790. Maximum Number of Groups With Increasing Length
         * Problem: https://leetcode.com/problems/maximum-number-of-groups-with-increasing-length/
         */
        //public static int MaxIncreasingGroups(IList<int> usageLimits)
        //{
        //    var dist = usageLimits.Count; // number of distinct nums
        //    var groupSize = 1;
        //    var count = 1;
        //    usageLimits = usageLimits.OrderByDescending(x => x).ToList();

        //    while (groupSize < dist)
        //    {
        //        // greedily use the ones with the most usage lims first
        //        int i = 0, numUsed = 0;
        //        while(numUsed < groupSize)
        //        {
        //            usageLimits[i] = usageLimits[i] - 1;

        //            if (usageLimits[i] == 0)
        //            {
        //                usageLimits.RemoveAt(i);
        //            }
        //            else
        //            {
        //                i++;
        //            }

        //            if (usageLimits.Count < groupSize + 1)
        //            {
        //                return count;
        //            }

        //            numUsed++;
        //        }

        //        usageLimits = usageLimits
        //            .OrderByDescending(x => x)
        //            .ToList();

        //        count++;
        //        groupSize++;
        //    }

        //    return count;
        //}

        public static int MaxIncreasingGroups(IList<int> usageLimits)
        {
            var sumUsageLim = usageLimits.Where(x => x > 1).Sum(x => x) + 1;

            double maxGroup = (-1 + Math.Sqrt(1 + 4 * (2 * sumUsageLim))) / 2;
            int maxGroupSize = Math.Min((int)Math.Floor(maxGroup), usageLimits.Count);

            return maxGroupSize;
        }
    }

}
