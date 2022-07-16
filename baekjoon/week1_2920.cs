using System;
using static System.Console;
using System.Text;
using System.IO;

namespace study
{
    class Baekjoon_2920
    {
        static void Main()
        {
            string[] input = ReadLine().Split();

            bool ascending = false;
            bool descending = false;

            int[] nums = new int[8];

            for (int i = 0; i < 8; i++)
            {
                nums[i] = int.Parse(input[i]);
            }

            int checkValue = nums[0];

            for (int i = 0; i < 8; i++)
            {
                if ((nums[0] == 1) && (checkValue <= nums[i]))
                {
                    checkValue = nums[i];
                    ascending = true;
                }
                else if ((nums[0] == 8) && (checkValue >= nums[i]))
                {
                    checkValue = nums[i];
                    descending = true;
                }
                else
                {
                    descending = false;
                    ascending = false;
                    break;
                }
            }

            if (ascending)
            {
                WriteLine("ascending");
            }
            else if (descending)
            {
                WriteLine("descending");
            }
            else
                WriteLine("mixed");
        }
    }
}