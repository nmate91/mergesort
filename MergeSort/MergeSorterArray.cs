using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class MergeSorterArray
    {
        public List<int> Merge(List<int> leftNumbers, List<int> rightNumbers)
        {
            if (leftNumbers.Count == 0) { return leftNumbers; }
            if (rightNumbers.Count == 0) { return rightNumbers; }
            int i = 0;
            int j = 0;
            List<int> result = new List<int>();
            while (result.Count < (leftNumbers.Count + rightNumbers.Count))
            {
                int right = rightNumbers.Count > j ? rightNumbers.ElementAt(j) : int.MaxValue;
                int left = leftNumbers.Count > i ? leftNumbers.ElementAt(i) : int.MaxValue;
                if (left <= right)
                {
                    result.Add(left);
                    ++i;
                }
                else
                {
                    result.Add(right);
                    ++j;
                }
                if (i == leftNumbers.Count)
                {
                    foreach (int item in rightNumbers.Skip(j))
                    {
                        result.Add(item);
                    }
                }
                if (j == rightNumbers.Count)
                {
                    foreach (int item in leftNumbers.Skip(i))
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        public List<int> Sort(List<int> numbers)
        {
            if (numbers.Count < 2) { return numbers; }
            int middle = (int)(numbers.Count / 2);
            List<int> rightNumbers = Sort(numbers.Skip(middle).ToList());
            List<int> leftNumbers = Sort(numbers.Take(middle).ToList());
            return Merge(leftNumbers, rightNumbers);
        }
    }
}
