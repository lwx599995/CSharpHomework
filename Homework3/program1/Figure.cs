using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//图像的处理
namespace FigureClass
{
    public interface Figure
    {
        double getArea(double param1,double param2);//用两个参数计算图形面积   
    }
    //三角形类
    public class Triangle : Figure
    {
        public double getArea(double ButtonLength, double Height)
        {
            return 0.5 * ButtonLength * Height;
        }
    }
    //椭圆形类
    public class Circle : Figure
    {
        public double getArea(double Radius1,double Radius2)
        {
            return 3.14 * Radius1 * Radius2;
        }
    }
    //矩形类
    public class Rectangle : Figure
    {
     
        public double getArea(double Length, double Width)
        {
            return Length * Width;
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
                case "椭圆形":
                    return new Circle();
                case "矩形":
                    return new Rectangle();

                default:
                    throw new Exception("工厂中没有该图形");
            }
        }
    }

}
