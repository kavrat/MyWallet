using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        /// <summary>
        /// Bubble sorting
        /// </summary>
        /// <param name="arr"></param>
        static void BubbleSort(int [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0, k = j + 1 ; k < arr.Length - i; j++, k++)
                {
                    if (arr[j] > arr[k])
                    {
                        Swap(ref arr[j], ref arr[k]);
                    }
                }
            }
        }

        /// <summary>
        /// Insertion sorting
        /// </summary>
        /// <param name="arr"></param>
        static void InsertionSort(int [] arr)
        {
            int j = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                j = i;
                while ((j > 0)&& (arr[j] < arr[j - 1]))
                {
                    Swap(ref arr[j], ref arr[j - 1]);
                    j = j - 1;
                }
            }
        }
        static string Show(int [] arr)
        {
            string output = "";
            for (int i = 0; i < arr.Length; i++)
            {
                output += String.Format(" {0}", arr[i]);
            }
            return output;
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 3, 8, 1, 4 };
            //BubbleSort(array);
            InsertionSort(array);

            Console.WriteLine(Show(array));
            Console.ReadKey();


        }
    }
}
