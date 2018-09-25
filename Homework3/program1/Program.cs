using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FigureClass;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            double Area = 0;
            FigureFactory Factory = new FigureFactory();

            //从工厂中创建三角形，并计算面积
            Figure A = Factory.CreateFigure("三角形"); 
            Area = A.getArea(10,100);
            Console.WriteLine("创建三角形，其面积为：" + Area);

            //从工厂中创建圆形，并计算面积
            Figure B = Factory.CreateFigure("椭圆形"); 
            Area = B.getArea(10, 10);
            Console.WriteLine("创建圆形，其面积为：" + Area);

            //从工厂中创建正方形，并计算面积
            Figure C = Factory.CreateFigure("矩形"); 
            Area = C.getArea(10, 10);
            Console.WriteLine("创建正方形，其面积为：" + Area);

            //从工厂中创建长方形，并计算面积
            Figure D = Factory.CreateFigure("矩形"); 
            Area = D.getArea(10, 30);
            Console.WriteLine("创建长方形，其面积为：" + Area);
            Console.ReadKey();
        }
    }
}
