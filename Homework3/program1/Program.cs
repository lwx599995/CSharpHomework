using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace program1
{
    //图形抽象类
    public abstract class Figure
    {
        public abstract void setInformation(double one);
        public abstract void setInformation(double one, double two);
        public abstract void setInformation(double one, double two, double three);
        public abstract void display();
    }
    //三角形类
    public class Triangle : Figure
    {
        public override void setInformation(double one) { }
        public override void setInformation(double one, double two) { }
        private double side1, side2, side3;
        public override void setInformation(double one, double two, double three)
        {
            side1 = one; side2 = two; side3 = three;
        }
        public override void display()
        {   //用海伦公式计算三角形面积
            double Area = Math.Sqrt(((side1 + side2 + side3) / 2) * (side2 / 2 + side3 / 2 - side1 / 2) *
                (side1 / 2 + side3 / 2 - side2 / 2) * (side1 / 2 + side2 / 2 - side3 / 2)); 
            Console.Write($"产生的三角形三边为：{side1},{side2},{side3}\n");
            Console.Write($"其面积为：{Area}\n\n");
        }
    }

    //圆形类
    public class Circle : Figure
    {
        public override void setInformation(double one, double two) { }
        public override void setInformation(double one, double two, double three) { }
        private double radius;
        public override void setInformation(double one)
        {
            radius = one;
        }
        public override void display()
        {
            double Area = 3.14 * radius * radius;
            Console.Write($"产生的圆形半径为：{radius}\n");
            Console.Write($"其面积为：{Area}\n\n");
        }
    }
    //正方形类
    public class Square : Figure
    {
        public override void setInformation(double one, double two) { }
        public override void setInformation(double one, double two, double three) { }
        private double side;
        public override void setInformation(double one)
        {
            side = one;
        }
        public override void display()
        {
            double Area = side * side;
            Console.Write($"产生的正方形边长为：{side}\n");
            Console.Write($"其面积为：{Area}\n\n");
        }
    }

    //矩形类
    public class Rectangle : Figure
    {
        public override void setInformation(double one) { }
        public override void setInformation(double one, double two, double three) { }
        private double side1, side2;
        public override void setInformation(double one, double two)
        {
            side1 = one; side2 = two;
        }
        public override void display()
        {
            double Area = side1 * side2;
            Console.Write($"产生的矩形的两边为：{side1},{side2}\n");
            Console.Write($"其面积为：{Area}\n\n");
        }
    }
    //简单工厂类 
    public class FigureFactory
    {
        public Figure CreateFigure(string FigureName)
        {
            switch (FigureName)
            {
                case "三角形":
                    return new Triangle();
                case "圆形":
                    return new Circle();
                case "正方形":
                    return new Square();
                case "矩形":
                    return new Rectangle();
                default:
                    throw new Exception("工厂中没有该图形");
            }
        }
    }


  class Program
    {
        static void Main(string[] args)
        {
            FigureFactory Factory = new FigureFactory();

            //从工厂中创建三角形，并计算面积
            Figure A = Factory.CreateFigure("三角形");
            A.setInformation(3, 4, 5);
            A.display();

            //从工厂中创建圆形，并计算面积
            Figure B = Factory.CreateFigure("圆形");
            B.setInformation(10);
            B.display();

            //从工厂中创建正方形，并计算面积
            Figure C = Factory.CreateFigure("正方形");
            C.setInformation(10);
            C.display();

            //从工厂中创建长方形，并计算面积
            Figure D = Factory.CreateFigure("矩形");
            D.setInformation(10, 30);
            D.display();
            Console.ReadKey();
        }
    }
}
