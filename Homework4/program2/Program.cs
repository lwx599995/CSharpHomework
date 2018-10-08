using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Service;
using My_Exception;
namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderService.InitOrder();  //初始化订单
                OrderService.Show();
                OrderService.Add("d4", "peach", "麦克", 12);  //增加订单
                OrderService.Show();
                OrderService.Delete(1); //删除第二列的订单
                OrderService.Show();
                OrderService.Modify(1, "f5", "mango", "杰森", 100);  //修改第二列的订单
                OrderService.Show();
                OrderService.ReferByOrderNumbers("a1");  //按订单号码查询
                OrderService.ReferByGoodsName("mango");  //按商品名称查询
                OrderService.ReferByClientName("麦克");  //按客户名字查询
                OrderService.Delete(100);  //删除失败例子
            }
            catch (DeleteException )
            {
                Console.Write("要删除的订单不存在，请检查");
                Console.ReadKey();
            }
            catch (ModifyException )
            {
                Console.Write("要修改的订单不存在，请检查");
                Console.ReadKey();
            }
        }
    }
}
