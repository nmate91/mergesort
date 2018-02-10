using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MergeSorter
    {
        public LinkedList<int> Merge(LinkedList<int> leftNumbers, LinkedList<int> rightNumbers)
        {
            if(leftNumbers.Count == 0) { return leftNumbers; }
            if(rightNumbers.Count == 0) { return rightNumbers; }
            LinkedList<int> result = new LinkedList<int>();
            int i = 0;
            int j = 0;
            while (result.Count < (leftNumbers.Count + rightNumbers.Count))
            {
                int right = rightNumbers.Count > j ? rightNumbers.ElementAt(j) : int.MinValue;
                int left = leftNumbers.Count > i ? leftNumbers.ElementAt(i) : int.MinValue;
                if (left < right)
                {
                    result.AddLast(left);
                    ++i;
                }
                else
                {
                    result.AddLast(right);
                    ++j;
                }
                if(i == leftNumbers.Count)
                {
                    foreach (int item in leftNumbers)
                    {
                        result.AddLast(item);
                    }
                    break;
                }
                if(j == rightNumbers.Count)
                {
                    foreach (int item in rightNumbers)
                    {
                        result.AddLast(item);
                    }
                    break;
                }
            }
            return result;
        }

        public LinkedList<int> Sort(LinkedList<int> numbers)
        {
            if(numbers.Count < 2) { return numbers; }
            int middle = (int)(numbers.Count / 2);
            LinkedList<int> rightNumbers = Sort(new LinkedList<int>(numbers.Skip(middle)));
            LinkedList<int> leftNumbers = Sort(new LinkedList<int>(numbers.Except(rightNumbers)));
            return Merge(leftNumbers, rightNumbers);
        }
    }
}