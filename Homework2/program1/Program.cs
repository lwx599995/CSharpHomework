using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//分解质因数
namespace program1
{
    class Program
    {
        //对输入的数进行判断
        private static int Judge(int n)
        {
            if (n <= 2)
                return 0;//输入的数不在范围内
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                        return 2;  //是合数，可以分解
                }
                return 1;//是素数，不能分解
            }
        }
        //根据判断的结果进行处理
        private static void FindAnswer(int n)
        {

            switch (Judge(n))
            {
                case 0:
                    Console.Write($"{n}不是大于2的整数，请重启再输入\n");break;
                case 1:
                    Console.Write($"{n}是素数，不能分解\n");break;
                case 2:
                    string Result = n.ToString() + " = ";
                    for (int i = 2; i <= n; i++)
                    {
                        if (n % i == 0)
                        {
                            Result += i.ToString() + " * ";
                            n = n / i;
                            i--;
                        }
                    }
                    Result = Result.Substring(0, Result.Length - 2);
                    Console.WriteLine($"该数为合数，可以分解为{Result}\n");
                    break;
            }


        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("请输入大于2的整数(退出程序请直接停止调试)\n");
                string s = Console.ReadLine();
                int number = Int32.Parse(s);
                FindAnswer(number);
            }

        }
    }
}
