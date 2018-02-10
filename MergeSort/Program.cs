using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSorter sorter = new MergeSorter();
            int[] array = new int[] { 3, 4, 5, -1, 2, 8, 3, 7, 6 };
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            var sorted = sorter.Sort(new LinkedList<int>(array));
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
    }
}
