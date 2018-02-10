using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class MergeSorter_Array
    {
        public List<int> Merge(List<int> leftNumbers, List<int> rightNumbers)
        {
            if (leftNumbers.Count == 0) { return leftNumbers; }
            if (rightNumbers.Count == 0) { return rightNumbers; }
            List<int> result = new List<int>();
            int i = 0;
            int j = 0;
            while (result.Count < (leftNumbers.Count + rightNumbers.Count))
            {
                int right = rightNumbers.Count > j ? rightNumbers[j] : int.MinValue;
                int left = leftNumbers.Count > i ? leftNumbers[i] : int.MinValue;
                if (left > right)
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
                    foreach (int item in leftNumbers.Except(leftNumbers.Skip(i)))
                    {
                        result.Add(item);
                    }
                    break;
                }
                if (j == rightNumbers.Count)
                {
                    foreach (int item in rightNumbers.Except(rightNumbers.Skip(j)))
                    {
                        result.Add(item);
                    }
                    break;
                }
            }
            return result;
        }

        public List<int> Sort(List<int> numbers)
        {
            if (numbers.Count < 2) { return numbers; }
            int middle = (int)(numbers.Count / 2);
            List<int> rightNumbers = Sort(numbers.Skip(middle).ToList());
            List<int> leftNumbers = Sort(numbers.Except(rightNumbers).ToList());
            return Merge(leftNumbers, rightNumbers);
        }
    }
}
