using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class HashTableQuestion
    {

        /*
         * Single Number
         * Problem: https://leetcode.com/problems/single-number/
         * Solution using HashSet:
         * - Space complexity: O(n)
         * - Time complexity: O(n)
         * 
         */
        public static int SingleNumber(int[] nums)
        {
            var occurence = new Dictionary<int, int>();

            foreach(var x in nums)
            {
                occurence[x] = occurence.ContainsKey(x) ? occurence[x] + 1 : 1;
            }
            
            return occurence.Where(x => x.Value == 1).First().Key;
        }

        /*
         * Intersection of Two Aeeays I
         * Problem: https://leetcode.com/problems/intersection-of-two-arrays/
         * Solution complexity:
         *  - Time: O(n + m)
         *  - Space: O(n)
         */
        public static int[] Intersection(int[] nums1, int[] nums2)
        {
            var isNumInIntersection = new Dictionary<int, bool>();

            foreach(var x in nums1)
            {
                if(isNumInIntersection.ContainsKey(x))
                {
                    continue; 
                }
                isNumInIntersection.Add(x, false);
            }

            foreach(var x in nums2)
            {
                if (isNumInIntersection.ContainsKey(x))
                {
                    isNumInIntersection[x] = true;
                }
            }

            return isNumInIntersection
                .Where(x => x.Value)
                .Select(x =>  x.Key)
                .ToArray();
        }

        /*
         * Happy Number
         * Problem: https://leetcode.com/problems/happy-number/
         * Note: Un-happy numbers result in an endless loop 
         * so all we need to do is detect when the loop starts (where a repeated sum is found)
         */
        public static bool IsHappy(int n)
        {            
            var digits = IntToDigitsArray(n);
            var sumDigitsSquared = digits.Sum(x => x*x);
            var prevSumOfDigitsSquared = new HashSet<int>();

            while(!prevSumOfDigitsSquared.Contains(sumDigitsSquared))
            {
                if(sumDigitsSquared == 1)
                {
                    return true;
                }
                else
                {
                    prevSumOfDigitsSquared.Add(sumDigitsSquared);
                    digits = IntToDigitsArray(sumDigitsSquared);
                    sumDigitsSquared = digits.Sum(x => x * x);

                    if(prevSumOfDigitsSquared.Contains(sumDigitsSquared))
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public static int[] IntToDigitsArray(int n)
        {
            return n.ToString().Select(x => int.Parse(x.ToString())).ToArray();
        }

        /*
         * Two Sum
         * Problem: https://leetcode.com/problems/two-sum/description/
         * Using hash map <target - num[i], i>:
         *  - Space complexity: O(n)
         *  - Time complexity: O(n)
         *  - Worst case: the two numbers are at the start and end of nums
         */
        public static int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    return new int[] { i, map[nums[i]] };
                }
                else
                {
                    var complement = target - nums[i];
                    map[complement] = i;
                }
            }

            return new int[0];
        }

        /*
         * Isomorphic Strings
         * Problem: https://leetcode.com/problems/isomorphic-strings/description/
         * - Time complexity: O(n)
         * - Space complexity: O(1) (there are 26 letters in the English alphabet so the max number of keys is 26)
         */
        public static bool IsIsomorphic(string s, string t)
        {
            var charMapST = new Dictionary<char, char>(); // character map s to t
            var charMapTS = new Dictionary<char, char>(); // character map t to s

            for (int i = 0; i < s.Length; i++)
            {
                if (charMapST.ContainsKey(s[i]) && charMapST[s[i]] != t[i]) 
                {
                    return false;
                }
                else if(charMapTS.ContainsKey(t[i]) && charMapTS[t[i]] != s[i])
                {
                    return false;
                }

                charMapST[s[i]] = t[i];
                charMapTS[t[i]] = s[i];
            }

            return true;
        }

        /*
         * Minimum Index Sum of Two Lists
         * Problem: https://leetcode.com/problems/minimum-index-sum-of-two-lists/description/
         * - Time complexity: O(l1 + l2)
         * - Space coomplexity: O(l * x)
         *  where l is the smaller list length and x is the average string size
         */
        public static string[] FindRestaurant(string[] list1, string[] list2)
        {
            var stringIndexMap1 = new Dictionary<string, int>();
            var sumCommonStringIndexMap = new Dictionary<string, int>();
            var minIndex = list1.Length + list2.Length;

            for (int i = 0; i < list1.Length; i++)
            {
                stringIndexMap1[list1[i]] = i;
            }

            for (int i = 0; i < list2.Length; i++)
            {
                if (stringIndexMap1.ContainsKey(list2[i]))
                {
                    var sumIndex = stringIndexMap1[list2[i]] + i;
                    sumCommonStringIndexMap[list2[i]] = sumIndex;
                    
                    if(sumIndex < minIndex)
                    {
                        minIndex = sumIndex;
                    }
                }
            }

            return sumCommonStringIndexMap
                .Where(x => x.Value == minIndex)
                .Select(x => x.Key)
                .ToArray();
        }

        /*
         * First Unique Char in a String
         * Problem: https://leetcode.com/problems/first-unique-character-in-a-string/description/
         * - Time complexity: O(n)
         * - Space complexity: O(1) (there are 26 letters in the English alphabet so the max number of keys is 26)
         */
        public static int FirstUniqChar(string s)
        {
            var charOccurenceIndexMap = new Dictionary<char,int[]>();
            
            for(int i = 0; i < s.Length; i++)
            {
                if (charOccurenceIndexMap.ContainsKey(s[i]))
                {
                    charOccurenceIndexMap[s[i]][0] += 1;
                }
                else 
                { 
                    charOccurenceIndexMap[s[i]] = new int[] {1, i}; 
                }
            }

            var firstUniqueChar = charOccurenceIndexMap.Values
                .FirstOrDefault(x => x[0] == 1) ?? new int[0];

            return firstUniqueChar.Any() ? firstUniqueChar[1] : -1;
        }

        /*
         * Intersection of Two Arrays II
         * Problem: https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
         * 
         * Optimisation strats:
         *  - Build the hash map based on the smaller array to save space and time iterating through the map
         *  - Because the hash map already has all the info needed from nums1, we can reuse nums1 as the result array to save even more space
         *  - If x appears in both nums1 and nums2:
         *   + If x appears in nums1 more times than nums2: hashMap[x] > occurence of x in nums2
         *   + Else: hashMap[x] < occurence of x in nums2
         */
        public static int[] IntersectII(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return IntersectII(nums2, nums1);
            }

            var numCount1 = new Dictionary<int, int>();

            // count occurence of ints in nums1
            for(int i = 0; i <  nums1.Length; i++)
            {
                numCount1[nums1[i]] = numCount1.TryGetValue(nums1[i], out var value) ? value + 1 : 1;
            }

            int intersectionLength = 0;
            for(int i = 0; i < nums2.Length; i++)
            {
                var count = numCount1.TryGetValue(nums2[i], out var value) ? value : 0;

                if(count > 0)
                {
                    nums1[intersectionLength] = nums2[i];
                    intersectionLength++;
                    numCount1[nums2[i]]--;
                }
            }

            return nums1.Take(intersectionLength).ToArray();
        }

        /*
         * Contains Duplicate II
         * Problem: https://leetcode.com/problems/contains-duplicate-ii/description/
         * 
         * Initial observations:
         *  - abs(i - j) is the distance between nums[i] and nums[j] in the array
         *  - The question could be reworded as follows:
         *   Given an array nums, find if there are two duplicate numbers 
         *   that are within k distance of each other.
         *   => The sliding window is of size min(m, k)
         *  - If we iterate through the array starting from index 0,
         *   then at any time abs(i - lastSeenIndex) = i - lastSeenIndex <= k
         *   In other words: i <= k + lastSeenIndex
         *   So we only need to map the number to the index of its last occurence
         *   
         *  Time complexity: O(n)
         *  Space complexity: O(min(m, k))
         */
        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if(k == 0 || nums.Length == 1)
            {
                return false;
            }

            var mostRecentIndexMap = new Dictionary<int,int>();

            for(int i = 0; i < nums.Length; i++)
            {
                if (mostRecentIndexMap.ContainsKey(nums[i]))
                {
                    if (i <= k + mostRecentIndexMap[nums[i]])
                    {
                        return true;
                    }
                }

                // update most recent index
                mostRecentIndexMap[nums[i]] = i;
            }

            return false;
        }

        /*
         * Group Anagrams
         * Problem: https://leetcode.com/problems/group-anagrams/description/
         * Two anagrams are equals when their characters are sorted alphabetically
         */
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagramMap = new Dictionary<string, IList<string>>();

            for(int i = 0;i < strs.Length;i++)
            {
                var sortedString = String.Concat(strs[i].OrderBy(c => c));

                if (anagramMap.ContainsKey(sortedString))
                {
                    anagramMap[sortedString].Add(strs[i]);
                }
                else
                {
                    anagramMap[sortedString] = new List<string>() { strs[i] };
                }
            }

            return anagramMap.Values.ToList();
        }

        /*
         * Group Shifted String
         * Problem: https://leetcode.com/problems/group-shifted-strings/description/
         */
        public static IList<IList<string>> GroupStrings(string[] strings)
        {
            var groupedStrings = new Dictionary<string, IList<string>>();

            foreach (string s in strings)
            {
                var dist = ShiftStringToStartFromA(s);
                if (groupedStrings.ContainsKey(dist))
                {
                    groupedStrings[dist].Add(s);
                }
                else
                {
                    groupedStrings[dist] = new List<string>() { s };
                }
            }

            return groupedStrings.Values.ToList();
        }
        
        public static string ShiftStringToStartFromA(string s)
        {
            int distFromA = (int)s[0] - 'a';
            var result = "a";

            if(s.Length > 1)
            {
                for(int i = 1; i < s.Length; i++)
                {
                    result += ShiftChar(s[i], distFromA);
                }
            }

            return result;
        }

        public static char ShiftChar(char c, int shiftNumber)
        {
            return (char) ((c - shiftNumber + 26) % 26 + 1);
        }

        /*
         * Jewels and Stones
         * Problem: https://leetcode.com/problems/jewels-and-stones/description/
         * 
         * Time complexity: O(j + s)
         * Space complexity: O(1) (52 case-sensitive chars at most)
         */
        public static int NumJewelsInStones(string jewels, string stones)
        {
            // build hash map from jewels
            var jewelCount = new Dictionary<char, int>();

            foreach (var j in jewels)
            {
                jewelCount[j] = 0;
            }

            foreach (var s in stones)
            {
                if(jewelCount.ContainsKey(s))
                {
                    jewelCount[s]++;
                }
            }

            return jewelCount.Values.Sum();
        }

        /*
         * Longest Substring Without Repeating Characters
         * Problem: https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
         * Use sliding window + hash set
         * 
         * Time complexity: O(n)
         * Space complexity: O(1) - 26 chars in alphabet
         */
        public static int LengthOfLongestSubstring(string s)
        {
            int start = 0, max = 1, duplicateCount = 0;
            var charSet = new HashSet<char>();

            if(s.Length == 0)
            {
                return 0;
            }

            for(int i = 0; i < s.Length; i++)
            {
                if (charSet.Contains(s[i]))
                {
                    duplicateCount++;
                }

                while(duplicateCount > 0)
                {
                    if (s[start] == s[i])
                    {
                        duplicateCount--;
                    }

                    charSet.Remove(s[start]);
                    start++;  // reducing the window size to where the first occurence of the duplicate
                }

                charSet.Add(s[i]);
                max = Math.Max(max, i - start + 1);
            }

            return max;
        }
    }

    /*
     * Two Sum III - Data structure design
     * Problem: https://leetcode.com/problems/two-sum-iii-data-structure-design/description/
     * 
     * Your TwoSum object will be instantiated and called as such:
     * TwoSum obj = new TwoSum();
     * obj.Add(number);
     * bool param_2 = obj.Find(value);
     */
    public class TwoSum
    {
        private Dictionary<int,int> intCount;
        public TwoSum()
        {
            intCount = new Dictionary<int,int>();
        }

        public void Add(int number)
        {
            var count = intCount.TryGetValue(number, out int val) ? val : 0;
            intCount[number] = count + 1;
        }

        public bool Find(int value)
        {
            foreach(int i in intCount.Keys)
            {
                var comp = value - i;

                if (intCount.ContainsKey(comp))
                {
                    if ((comp*2 == value && intCount[comp] > 1) || comp * 2 != value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    /*
    * Logger Rate Limiter
    * Problem: https://leetcode.com/problems/logger-rate-limiter/description/
    * 
    * Your Logger object will be instantiated and called as such:
    *  Logger obj = new Logger();
    *  bool param_1 = obj.ShouldPrintMessage(timestamp,message);
    *  
    * Initial observations:
    *  - The sliding window size is 10
    *  - We only need to remember the timestamp of the last message
    *  - Similar to "Contains Duplicate II" above but we don't care about the duplicates in between the window
    */
    public class Logger
    {
        private Dictionary<string, int> nextMessageTimeStamp;
        private const int windowSize = 10;

        public Logger()
        {
            nextMessageTimeStamp = new Dictionary<string, int>();
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            var nextTs = nextMessageTimeStamp.TryGetValue(message, out int time) ? time : 0;

            if (nextTs > 0)
            {
                if(nextTs > timestamp)
                {
                    return false;
                }
            }

            nextMessageTimeStamp[message] = timestamp + windowSize;
            return true;
        }
    }

    /*
     *  Design Hashset
     *  Problem description: https://leetcode.com/problems/design-hashset/
     *  
     *  MyHashSet object will be instantiated and called as such:
     *   MyHashSet obj = new MyHashSet();
     *   obj.Add(key);
     *   obj.Remove(key);
     *   bool param_3 = obj.Contains(key);
     *
     *  Constraints:
     *   0 <= key <= 10^6
     *   At most 10^4 calls will be made to add, remove, and contains.
     *   
     *  Naive solution: Store the values in an array of 10^6 and using the index as the hash function
     *  Alternatives:
     *   1. Linked list for each bucket => worst case scenario: key is at the end of the bucket
     *   2. Binary search tree for each bucket => faster to search in each bucket
     *   
     *  Hash function chosen: h(key) = key % table_size
     *   where table_size is the largest prime number that is smaller than 10^6 (= 999983)
     */
    public class MyHashSet
    {
        public const int TableSize = 999983;
        public BinarySearchTree[] Buckets { get; set; }

        public MyHashSet()
        {
            Buckets = new BinarySearchTree[TableSize];
        }

        public void Add(int key)
        {
            var hashValue = Hash(key);
            // if key doesn't exist
            if (Buckets[hashValue] == null)
            {
                Buckets[hashValue] = new BinarySearchTree(key);
            }
            // in case of colision
            else
            {
                Buckets[hashValue].Add(key);
            }
        }

        public void Remove(int key)
        {
            var hashValue = Hash(key);
            // if key doesn't exist
            if (Buckets[hashValue] == null || !Buckets[hashValue].Contains(key))
            {
                return;
            }
            else
            {
                Buckets[hashValue].Remove(key);
            }
        }

        public bool Contains(int key)
        {
            var hashValue = Hash(key);
            return Buckets[hashValue] != null && Buckets[hashValue].Contains(key);
        }

        public int Hash(int key)
        {
            return key % TableSize;
        }
    }

    /*
     * Design a Hash Map
     * Problem description: https://leetcode.com/problems/design-hashmap/
     */
    public class MyHashMap
    {
        public const int TableSize = 999983;
        public BinarySearchTree[] Buckets { get; set; }

        public MyHashMap()
        {
            Buckets = new BinarySearchTree[TableSize];
        }
        public int Hash(int key)
        {
            return key % TableSize;
        }
    
        public void Put(int key, int value)
        {
            var hashValue = Hash(key);
            // if key doesn't exist
            if (Buckets[hashValue] == null)
            {
                Buckets[hashValue] = new BinarySearchTree(key, value);
            }
            // in case of colision
            else
            {
                Buckets[hashValue].Add(key, value);
            }
        }

        public int Get(int key)
        {
            var hashValue = Hash(key);
            return Buckets[hashValue] != null ?
                Buckets[hashValue].Search(key) : -1;
        }

        public bool ContainsKey(int key)
        {
            return Get(key) != -1;
        }

        public void Remove(int key)
        {
            var hashValue = Hash(key);
            if (ContainsKey(key))
            {
                Buckets[hashValue].Remove(key);
            }
        }
    }

}
