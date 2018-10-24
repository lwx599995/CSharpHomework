using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace ordertest
{
   public class OrderService
    {
        public Dictionary<string, Order> orderDict;
        public double TotalPrise { get; set; }
        public OrderService()
        {
           orderDict = new Dictionary<string, Order>();
        }
        //添加订单
        public bool AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
            {
                return false;
                throw new Exception($"order-{order.Id} is already existed!");
            }
            orderDict[order.Id] = order;
            return true;
        }
        //移除订单
        public bool RemoveOrder(string orderId) 
        {
            try
            {
                orderDict.Remove(orderId);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        //查询所有订单
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }
        //按订单号查找
        public Order GetById(string orderId)
        {
            return orderDict[orderId];
        }
        //按商品名称查找
        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0);
            return query.ToList();
        }
        //按客户名单查找
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer == customerName);
            return query.ToList();
        }
        //按订单总额查找（订单额不低于多少的订单）
        public List<Order> QueryByTotalPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.getTotalPrice() >= price);
            return query.ToList();
        }
        //将订单XML序列化
        public bool  Export(string xmlFileName)
        {
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                FileStream fs = new FileStream(xmlFileName, FileMode.Create);
                xmlser.Serialize(fs,orderDict.Values.ToList());
                fs.Close();
                Console.Write("订单XML序列化成功\n");
                return true;
            }
            catch (Exception)
            {
                Console.Write("订单XML序列化失败\n");
                return false;
            }

        }
        //从XML文件中读取订单
        public bool Import(string xmlFileName)
        {
            try
            {
                List<Order> MyOrder = new List<Order>();
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                FileStream fs = new FileStream(xmlFileName, FileMode.Open);
                MyOrder = (List<Order>)xmlser.Deserialize(fs);
                foreach (Order order in MyOrder)
                    this.AddOrder(order);
                Console.Write("从XML文件中读取并添加订单成功\n");
                return true;
            }
            catch (Exception)
            {
                Console.Write("从XML文件中读取并添加订单失败\n");
                return false;
            }
        }

    }
}
