using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
namespace sutdy
{
    internal class Baekjoon_5397
    {
        static void Main(string[] args)
        {
            string[] input = ReadLine().Split();
            string[] output = new string[input.Length];

            Stack<string> left = new Stack<string>();
            Stack<string> right = new Stack<string>();
            int cursor = 0;
            
            for (int i = 1; i <= input.Length; i++)
            {
                string text = input[i];

                if (text == "<")
                {
                    if(cursor == 0)
                        break;

                    cursor -= 1;
                    if(right.Count > 0)
                        right.Push(left.Pop());
                }
                else if (text == ">")
                {
                    cursor += 1;
                    if(left.Count > 0)
                        left.Push(right.Pop());
                }
                else if (text == "-")
                {
                    cursor -= 1;
                    if(left.Count > 0)
                        left.Pop();
                }
                else
                {
                    left.Push(text);
                    cursor += 1;
                }
            }

            for (int i = right.Count; i == 0; i--)
            {
                left.Push(right.Pop());
            }
            
            Console.WriteLine(left.ToString());
        }
    }
}