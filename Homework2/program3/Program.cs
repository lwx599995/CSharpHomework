using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//用埃式算法求2-100内的质数
namespace program3
{
    class Program
    {      
        //将原数组中值为flag的n（n>1）倍的数的值赋值为0
        private static void SetZero(int flag,int []Array)
        {
            for (int i = 1; i < 99; i++)
            {
                for (int j = 1; j * flag <= Array[i] && j*flag<=100 ; j++)
                {
                    if (Array[i] % (j * flag) == 0 && Array[i] != flag)
                        Array[i] = 0;
                }
            }
        }
        //输出不为0的数组元素
        private static void ShowResult(int []Array)
        {
            Console.Write("2-100的质数有\n");
            for (int i = 0; i < 99; i++)
            {
                if (Array[i] != 0)
                    Console.Write($"{Array[i]} ");
            }
        }
        static void Main(string[] args)
        {
            //数组初始化
            int[] A = new int[99];
            for (int i = 0; i < 99; i++)
                A[i] = i + 2;

            SetZero(2, A);
            SetZero(3, A);
            SetZero(5, A);
            SetZero(7, A);
            ShowResult(A);
        }
    }
}
