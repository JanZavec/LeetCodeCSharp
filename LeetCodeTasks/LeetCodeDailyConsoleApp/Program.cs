using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyConsoleApp
{
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

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 5 };
            Console.WriteLine(CanMakeArithmeticProgression(arr));
            Console.ReadLine();
        }
    }
}
