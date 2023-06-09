﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeDailyConsoleApp
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution
    {
        static List<List<int>> valuesatLevels = new List<List<int>>();
        private static void levelTraversal(TreeNode root, int level)
        {
            if (root == null) return;

            if (level >= valuesatLevels.Count)
            {
                valuesatLevels.Add(new List<int>());
            }

            valuesatLevels.ElementAt(level).Add(root.val);

            levelTraversal(root.left, level + 1);
            levelTraversal(root.right, level + 1);
        }

        private static int findMax(List<int> sums)
        {
            int max = sums[0];

            foreach (int value in sums)
            {
                if (value > max)
                    max = value;
            }
            return max;
        }
        public static int MaxLevelSum(TreeNode root)
        {
            levelTraversal(root, 0);
            List<int> sums = new List<int>(valuesatLevels.Count);
            valuesatLevels.ForEach(list => sums.Add(list.Sum()));

            return sums.IndexOf(findMax(sums)) + 1;

        }
        public int LargestAltitude(int[] gain)
        {
            int[] lat = new int[gain.Length + 1];
            lat[0] = 0;
            if (gain.Length == 1 && gain[0] > 0) return gain[0];
            if (gain.Length == 1 && gain[0] <= 0) return 0;
            if (gain.Length == 2) return gain[1] + gain[0];
            lat[1] = gain[0];
            for (int index = 2; index < gain.Length; index++)
            {
                lat[index] = lat[index - 1] + gain[index - 1];
            }
            lat[gain.Length] = lat[gain.Length - 1] + gain[gain.Length - 1];
            return lat.Max();
        }




        List<int> listOfValues = new List<int>();
        private void PreOrder_Rec(TreeNode root)

        {
            if (root != null)

            {
                listOfValues.Add(root.val);
                PreOrder_Rec(root.left);
                PreOrder_Rec(root.right);

            }

        }

        public int GetMinimumDifference(TreeNode root)
        {
            PreOrder_Rec(root);
            listOfValues.Sort();
            List<int> minDiff = new List<int>();
            int min = Int32.MaxValue;
            for (int i = 0; i < listOfValues.Count - 1; i++)
            {
                minDiff.Add(Math.Abs(listOfValues.ElementAt(i) - listOfValues.ElementAt(i + 1)));
            }
            return minDiff.Min();
        }

        internal class Program
        {
            public static bool CanMakeArithmeticProgression(int[] arr)
            {
                Array.Sort(arr);
                int commonLength = arr[1] - arr[0];
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if (arr[i + 1] - arr[i] != commonLength)
                    {
                        return false;
                    }

                }

                return true;
            }

            public static IList<string> SummaryRanges(int[] nums)
            {
                IList<string> result = new List<string>();
                int counter = 1;
                if (nums.Length == 1)
                {
                    result.Add($"{nums[0]}");
                    return result;
                }
                for (int i = 1; i < nums.Length; ++i)
                {
                    if (nums[i] == nums[i - 1] + 1)
                    {
                        ++counter;
                        continue;
                    }
                    else
                    {

                        if (nums[i - counter] != nums[i - 1])
                            result.Add($"{nums[i - counter]}->{nums[i - 1]}");
                        else
                            result.Add($"{nums[i - counter]}");
                        if (i == nums.Length - 1)
                            result.Add($"{nums[i]}");
                        counter = 1;
                    }

                }
                if (counter != 1)
                    result.Add($"{nums[nums.Length - counter]}->{nums[nums.Length - 1]}");
                return result;
            }

            public static int EqualPairs(int[][] grid)
            {
                int pairs = 0;
                for (int i = 0; i < grid.Length; ++i)
                {
                    int[] row = grid[i];

                    for (int j = 0; j < grid.Length; ++j)
                    {
                        var selectedArray = grid
                .Where(o => (o != null && o.Count() > j))
                .Select(o => o[j])
                .ToArray();
                        if (Enumerable.SequenceEqual(row, selectedArray)) pairs++;
                    }
                }

                return pairs;

            }

            public int SingleNumber(int[] nums)
            {
                // Group numbers, by their count which is 1 and check Single because there must be only 1 such number and get that key.
                var uniqueValues = nums.GroupBy(x => x).Where(g => g.Count() == 1);
                return uniqueValues.Single().Key;
            }

            static void Main(string[] args)
            {

                int[][] arr = { new[] { 3, 2, 1 }, new[] { 1, 7, 6 }, new[] { 2, 7, 7 } };
                List<List<int>> list = new List<List<int>>() { new List<int>() { 3 }, new List<int>() { 9, 20 }, new List<int>() { 15, 7 } };
                TreeNode root = new TreeNode(-100);
                root.left = new TreeNode(-200);
                root.right = new TreeNode(-300);
                root.left.left = new TreeNode(-20);
                root.left.right = new TreeNode(-5);
                root.right.left = new TreeNode(-10);
                Console.WriteLine(MaxLevelSum(root));
                Console.ReadLine();
            }
        }
    }
}
