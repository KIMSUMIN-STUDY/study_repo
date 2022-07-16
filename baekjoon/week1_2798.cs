using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace study
{
    class Baekjoon_2798
    {
        static int BlackJack(int[] SetData, int[] Data)
        {
            int Goal = SetData[1];
            int min = 0;
            int sum;

            for (int i = 0; i < Data.Length - 2; i++)
            {
                for (int j = i + 1; j < Data.Length - 1; j++)
                {
                    for (int k = j + 1; k < Data.Length; k++)
                    {
                        sum = Data[i] + Data[j] + Data[k];

                        if (sum == Goal)
                            return sum;

                        if (sum > Goal)
                            continue;

                        if (Goal - sum < Goal - min)
                            min = sum;
                    }
                }
            }

            return min;
        }

        public static void Main(string[] args)
        {
            // 설정값 입력
            string input = Console.ReadLine();

            string[] temp = input.Split(' ');
            int[] Settting = new int[temp.Length];
            int idx = 0;

            foreach (string num in temp)
            {
                Settting[idx] = Int32.Parse(num);
                idx++;
            }

            // 설정에 맞출 값
            input = Console.ReadLine();

            temp = input.Split(' ');
            int[] value = new int[temp.Length];
            idx = 0;

            foreach (string num in temp)
            {
                value[idx] = Int32.Parse(num);
                idx++;
            }

            Console.WriteLine(BlackJack(Settting, value));
        }
    }
}