using System;
public class Programone
{
    //从控制台获取数据
    private static double GetInput()
    {
        string s = Console.ReadLine();
        double x = Double.Parse(s);
        return x;
    }
    public static void Main(string[] args)
    {
        Console.Write("Please input two doubles!\n");
        double a = GetInput();
        double b = GetInput();
        Console.Write($"The product of two doubles is {a * b}");
    }
}
