using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace sutdy
{
    internal class Baekjoon_1874
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            StringBuilder sb = new StringBuilder();

            int pushCount = 1;
            int popCount = 0;

            for (int i = 1; i <= N; i++)
            {
                int num = Convert.ToInt32(Console.ReadLine());
                
                while(num >= pushCount)
                {
                    sb.AppendLine("+");
                    stack.Push(pushCount);
                    pushCount++;
                }
                
                if (num == stack.Peek())
                {
                    stack.Pop();
                    sb.AppendLine("-");
                    popCount++;
                }
            }

            if (popCount == N)
                Console.WriteLine(sb);
            else
                Console.WriteLine("NO");
        }
    }
}