using System;
using System.Collections;
namespace Exercise2
{
    class Solution
    {
        public static void solution(int[] A)
        {
            Hashtable hs = new Hashtable();
            int mostcommon = A[0];
            int occurence = 0;
            foreach (int num in A) {
                if (!hs.ContainsKey(num))
                {
                    hs.Add(num, 1);
                }
                else {
                    int tempOccurence = (int)hs[num];
                    tempOccurence++;
                    hs.Remove(num);
                    hs.Add(num, tempOccurence);
                    if (occurence < tempOccurence)
                    {
                        occurence = tempOccurence;
                        mostcommon = num;
                    }
                }
            }
            Console.WriteLine("The common number is " + mostcommon + "And it appears" + occurence + "times");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the array size:");
            int size= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the array elements:");
            string input = Console.ReadLine();
            string[] inputList = input.Split(' ');
            int[] array = new int[size];
            for (int i = 0; i < size; i++) {
                array[i] = Convert.ToInt32(inputList[i]);
            }
            solution(array);
        }
    }
}
