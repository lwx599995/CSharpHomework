using System;
using MySql.Data.MySqlClient;
using ordertest;

namespace MysqlTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer(1, "张三", 15270390336);
            Customer customer2 = new Customer(2, "李四", 13634097159);
            Goods apple = new Goods(3, "apple", 5.6);
            Goods egg = new Goods(2, "egg", 4.9);
            Goods milk = new Goods(1, "milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            Order order1 = new Order(20181111111, customer1);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            string connectStr = "server=localhost;port=3306;database=od;user=root;password=lwx.19993515;";
            //并没有建立数据库连接
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {   //建立连接，打开数据库
                conn.Open();
                string sqlstr = $"insert into orders(OrderID,Customer,Detials) values(" +
                    $"'{order1.Id.ToString()}'," +
                    $"'{order1.Customer.ToString()}'," +
                    $"{order1.Details.ToString()})";   
                MySqlCommand cmd = new MySqlCommand(sqlstr, conn);

                int result = cmd.ExecuteNonQuery();   //返回值为执行后数据库中受影响的数据行数
                Console.WriteLine("执行成功，影响了{0}行数据", result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                conn.Close();   //关闭连接
            }
            Console.ReadKey();
        }


        
    
}