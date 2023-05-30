using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeDailyConsoleApp
{
    public class MyHashSet
    {
        List<int> list;
        public MyHashSet()
        {
            list = new List<int>();
        }

        public void Add(int key)
        {
            if (list.Contains(key)) 
            {
                return;
            }
            list.Add(key);
        }

        public void Remove(int key)
        {
            list.Remove(key);
        }

        public bool Contains(int key)
        {
            return list.Contains(key);
        }
    }
}

/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet obj = new MyHashSet();
 * obj.Add(key);
 * obj.Remove(key);
 * bool param_3 = obj.Contains(key);
 */
