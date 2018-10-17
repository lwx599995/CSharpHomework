using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ordertest
{
    class OrderService
    {
        private Dictionary<string, Order> orderDict;
        public double TotalPrise { get; set; }
        public OrderService()
        {
            orderDict = new Dictionary<string, Order>();
        }
        //添加订单
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }
        //移除订单
        public void RemoveOrder(string orderId)
        {
            orderDict.Remove(orderId);
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
        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values)
            {
                var a = order.Details
                        .Where(detail => detail.Goods.Name == goodsName);
                foreach (OrderDetail b in a)
                    result.Add(order);
            }
            return result;
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
    }
}
