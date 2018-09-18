using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//求数组的最大值、最小值、平均值和总和
namespace program2
{
    class Program
    {
        //初始化数组
       static int[] A = new int[10] { 11, 85, 484, 745, 47, 48, 39, 4, 26, 599 };
        //程序入口,用于展示程序运行结果
        static void Main()
        {
            int max = GetMax();
            int min = GetMin();
            int sun = GetSum();
            double average = GetAverg();
            Console.WriteLine("原数组为{ 11,85, 484, 745, 47, 48, 39, 4, 26, 599 }");
            Console.WriteLine("最大值、最小值、平均值和总和分别为\n" +
                $"{max}、{min}、{average}、{sun}");
        }
        //求最大值
        private static int GetMax()
        {
            int Max = A[0];
            for (int i = 1; i < 10; i++)
            {
                if (Max < A[i])
                    Max = A[i];
            }
            return Max;
        }
        //求最小值
        private static int GetMin()
        {
            int Min = A[0];
            for (int i = 1; i < 10; i++)
            {
                if (Min > A[i])
                    Min = A[i];
            }
            return Min;
        }
        //求总和
        private static int GetSum()
        {
            int Sum = A[0];
            for (int i = 1; i < 10; i++)
            {
                Sum += A[i];
            }
            return Sum;
        }
        //求平均值
        private static double GetAverg()
        {
            int Sum = GetSum();
            double Average = Sum / 10.0;
            return Average;
        }
   
    }
}
