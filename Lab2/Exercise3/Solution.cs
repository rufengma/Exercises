using System;

namespace Exercise3
{
    class Solution
    {
        static int solution(int a, int b)
        {
            //initial result
            int cnt = 0;
            //traverse through all numbers
            for (int i = a; i <= b; i++)
            {
                for (int j = 1; j * j <= i; j++) {
                    if (j * j == i) {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        public static void Main(string[] args) {
            Console.WriteLine("Please enter A and B");
            string input=Console.ReadLine();
            string[] inputList = input.Split(' ');
            int inputA = Convert.ToInt32(inputList[0]);
            int inputB = Convert.ToInt32(inputList[1]);
            Console.WriteLine("Number of perfect square is: "+solution(inputA, inputB));
        }
    }
}
