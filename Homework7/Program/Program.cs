using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{

    class MainClass
    {
        public static void Main()
        {
            try
            {   
                //客户信息（名字）
                string customer1 = "Customer1";
                string customer2 = "Customer2";
                //商品信息（商品编号、名称、单价）
                Goods milk = new Goods("food_milk_800", "Milk", 69.9);
                Goods eggs = new Goods("food_egg_520", "eggs", 4.99);
                Goods apple = new Goods("food_apple_360", "apple", 5.59);
                //订单明细（交易编号、商品种类、交易数额）
                OrderDetail orderDetails1 = new OrderDetail("Mon100", apple,1780);
                OrderDetail orderDetails2 = new OrderDetail("Wed030", eggs, 20);
                OrderDetail orderDetails3 = new OrderDetail("Fri008", milk, 1);
                //订单信息（订单号、客户名称）
                Order order1 = new Order("a1", customer1);
                Order order2 = new Order("b1", customer2);
                Order order3 = new Order("c1", customer2);
                //为每笔订单添加信息
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);

                //将所有订单添加至订单管理器中
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);

                Console.WriteLine("GetAllOrders");
                List<Order> orders = os.QueryAllOrders();
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());


                Console.WriteLine("GetOrdersByCustomerName:'Customer2'");
                orders = os.QueryByCustomerName("Customer2");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("GetOrdersByGoodsName:'apple'");
                orders = os.QueryByGoodsName("apple");
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

                Console.WriteLine("QueryByTotalPrice:'>=10000'");
                orders = os.QueryByTotalPrice(10000);
                foreach (Order od in orders)
                    Console.WriteLine(od.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
