using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace заполнение_2го_массива_змейкой
{
    static class Extensions
    {
        public static void FillBySnakeStyle<T>(this T[,] arr, IEnumerable<T> sourceValues)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int maxCount = m * n;
            int mVector = 0;
            int nVector = 1;

            int mi = 0, ni = 0;

            foreach (var val in sourceValues.Take(maxCount))
            {
                arr[mi, ni] = val;
                mi += mVector;
                ni += nVector;
                if (nVector != 0)
                {
                    if (nVector < 0 && ni < m - mi)
                    {
                        mVector = -1;
                        nVector = 0;
                    }
                    if (nVector > 0 && ni >= n - mi - 1)
                    {
                        mVector = 1;
                        nVector = 0;
                    }
                }
                else if (mVector != 0)
                {
                    if (mVector < 0 && mi <= ni + 1)
                    {
                        mVector = 0;
                        nVector = 1;
                    }
                    if (mVector > 0 && mi > m - (n - ni) - 1)
                    {
                        mVector = 0;
                        nVector = -1;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[5, 5];
            arr.FillBySnakeStyle(Enumerable.Range(1, 26));
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write("{0,3}", arr[i, j] + "\t");
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}