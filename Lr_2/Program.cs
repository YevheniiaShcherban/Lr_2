using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Максимальна кількість повторень
            int[] nums = { 1, 0, 1, 1, 0, 1 };
            Console.WriteLine($"Task 1\n{string.Join(" ", nums)}");
            Console.WriteLine(MaxRepeats(nums));
            //Знайдіть числа з парною кількістю цифр
            nums = new int[] { 12, 345, 2, 6, 7896 };
            Console.WriteLine($"Task 2\n{string.Join(" ", nums)}");
            int count = CountEvenDigits(nums);
            Console.WriteLine(count);
            //Квадрати відсортованого масиву
            nums = new int[] { -7, -3, 2, 3, 11 };
            Console.WriteLine($"Task 3\n{string.Join(" ", nums)}");
            int[] squares = SquareSortedArray(nums);
            Console.WriteLine($"{string.Join(" ", squares)}");
            //Подвійні нулі 
            nums = new int[] { 1, 0, 2, 3, 0, 4, 5, 0 };
            Console.WriteLine($"Task 4\n{string.Join(" ", nums)}");
            DuplicateZero(ref nums);
            Console.WriteLine($"{string.Join(" ", nums)}\n");
            nums = new int[] { 1, 2, 3 };
            Console.WriteLine($"{string.Join(" ", nums)}");
            DuplicateZero(ref nums);
            Console.WriteLine($"{string.Join(" ", nums)}");
            //Об’єднати відсортований масив
            nums = new int[] { 1, 2, 3, 0, 0, 0 };
            int m = 3, n = 3;
            int[] nums2 = { 2, 5, 6 };
            Console.WriteLine($"Task 5\nnums1 = {string.Join(" ", nums)}\nnums2 = {string.Join(" ", nums2)}\nn = {n}, m = {m}");
            MergeSortedArrays(nums, m, nums2, n);
            Console.WriteLine($"{string.Join(" ", nums)}");
            //Видалити дублікати з відсортованого масиву
            nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            Console.WriteLine($"Task 6\n{string.Join(" ", nums)}");
            DeleteDuplicates(ref nums);
            Console.WriteLine($"{string.Join(" ", nums)}");
            //Чи існують N і його подвійник
            nums = new int[] { 3, 1, 7, 11 };
            Console.WriteLine($"Task 7\n{string.Join(" ", nums)}");
            bool exists = CheckIfExist(nums);
            Console.WriteLine(exists);
            //Дійсний гірський масив
            nums = new int[] { 3, 5, 5 };
            Console.WriteLine($"Task 8\n{string.Join(" ", nums)}");
            bool mountain = MountainArray(nums);
            Console.WriteLine(mountain);
            //Замініть елементи на найбільший елемент з правого боку
            nums = new int[] { 17, 18, 5, 4, 6, 1 };
            Console.WriteLine($"Task 9\n{string.Join(" ", nums)}");
            ReplaceElements(nums);
            Console.WriteLine($"{string.Join(" ", nums)}");
            //Відсортувати масив за парністю
            nums = new int[] { 3, 1, 2, 4 };
            Console.WriteLine($"Task 10\n{string.Join(" ", nums)}");
            int[] sort = SortByParity(nums);
            Console.WriteLine($"{string.Join(" ", sort)}");
        }
        //Максимальна кількість повторень
        static int MaxRepeats(int[] nums)
        {
            int maxRepeats = 0;
            int currentRepeats = 0;
            foreach (int num in nums)
            {
                if (num == 1) { currentRepeats++; }
                else
                {
                    if (currentRepeats > maxRepeats) { maxRepeats = currentRepeats; }
                    currentRepeats = 0;
                }
            }
            if (currentRepeats > maxRepeats) { maxRepeats = currentRepeats; }
            return maxRepeats;
        }
        //Знайдіть числа з парною кількістю цифр
        static int CountEvenDigits(int[] nums)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int digits = (int)Math.Log10(nums[i]) + 1;
                if (digits % 2 == 0) { count++; }
            }
            return count;
        }
        //Квадрати відсортованого масиву
        static int[] SquareSortedArray(int[] nums)
        {
            int[] squares = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                squares[i] = nums[i] * nums[i];
            }
            Array.Sort(squares);
            return squares;
        }
        //Подвійні нулі
        static void DuplicateZero(ref int[] nums)
        {
            int originalLength = nums.Length;
            int zeroCount = nums.Count(x => x == 0);
            int expandedLength = originalLength + zeroCount;
            Array.Resize(ref nums, expandedLength);
            for (int i = originalLength - 1, j = expandedLength - 1; i < j; i--, j--)
            {
                if (nums[i] == 0)
                {
                    nums[j] = 0;
                    j--;
                    nums[j] = 0;
                }
                else { nums[j] = nums[i]; }
            }
        }
        //Об’єднати відсортований масив
        static void MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int[] temp = new int[m + n];
            for (int i = 0; i < m; i++)
            {
                temp[i] = nums1[i];
            }
            for (int i = 0; i < n; i++)
            {
                temp[m + i] = nums2[i];
            }
            Array.Sort(temp);
            for (int i = 0; i < m + n; i++)
            {
                nums1[i] = temp[i];
            }
        }
        //Видалити дублікати з відсортованого масиву
        static int DeleteDuplicates(ref int[] nums)
        {
            if (nums.Length <= 1) { return nums.Length; }
            int k = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            Array.Resize(ref nums, k);
            return k;
        }
        //Чи існують N і його подвійник
        static bool CheckIfExist(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == 2 * nums[j]) { return true; }
                }
            }
            return false;
        }
        //Дійсний гірський масив
        static bool MountainArray(int[] nums)
        {
            if (nums.Length < 3) { return false; }
            int i = 0;
            while (i < nums.Length - 1 && nums[i] <= nums[i + 1]) { i++; }
            if (i == nums.Length - 1) { return false; }
            while (i < nums.Length - 1 && nums[i] >= nums[i + 1]) { i++; }
            return i == nums.Length - 1;
        }
        //Замініть елементи на найбільший елемент з правого боку
        static int[] ReplaceElements(int[] nums)
        {
            if (nums.Length == 0) { return nums; }
            int maxRight = nums[nums.Length - 1];
            nums[nums.Length - 1] = -1;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int currentElement = nums[i];
                nums[i] = maxRight;
                maxRight = Math.Max(maxRight, currentElement);
            }
            return nums;
        }
        //Відсортувати масив за парністю
        static int[] SortByParity(int[] nums)
        {
            int[] result = new int[nums.Length];
            int evenIndex = 0;
            int oddIndex = nums.Length - 1;
            foreach (var num in nums)
            {
                if (num % 2 == 0) { result[evenIndex++] = num; }
                else { result[oddIndex--] = num; }
            }
            return result;
        }
    }
}


