using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                
                for(int j = 0; j < grid.Length; ++j)
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

        static void Main(string[] args)
        {
            
            int[][] arr = { new[] { 3, 2, 1 }, new[] { 1, 7, 6 }, new[] { 2, 7, 7 } };
            Console.WriteLine(EqualPairs(arr));
            Console.ReadLine();
        }
    }
}
