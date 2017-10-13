using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int[][] arr = new int[6][];
        for (int arr_i = 0; arr_i < 6; arr_i++)
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
        }

        int sumHi = 0;
        //top to bottom
        for (int i = 0; i < 6; i++)
        {
            //left to right
            for (int j = 0; j < 6; j++)
            {
                int sum = 0;
                if (j + 2 < 6)
                {
                    if (i + 2 < 9)
                    {
                        //Top Row
                        sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2];
                        //Middle
                        sum += arr[i + 1][j + 1];
                        //Bottom Row
                        sum += arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                        if (sum > sumHi) { sumHi = sum; }
                    }
                }

            }
        }
    }
}
