using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class HashTableQuestion
    {

        /*
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
     * Problem description: https://leetcode.com/problems/design-hashmap/
     * 
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
