using System;
using System.Collections.Generic;

namespace ordertest
{
    [Serializable]
  public class Order
    {
        public List<OrderDetail> details = new List<OrderDetail>();
       // public Order() { }
        public Order(string orderId, string customer)
        {
            Id = orderId;
            Customer = customer;
        }
        public string Id { get; set; }
        public string Customer { get; set; }
        public List<OrderDetail> Details => this.details;
        //添加订单详情
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }
        //移除订单详情
        public void RemoveDetails(string orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }
        //计算订单总额
        public double getTotalPrice()
        {
            double tp = 0;
            foreach (OrderDetail od in this.Details)
            {
                tp += od.goodsPrice;
            }
            return tp;
        }
        public override string ToString()
        {
            string result = "-------------------------------------------------------------------------------------------------------------\r\n";
            result += $"orderId:{Id}, customer:{Customer}, totalPrice:{getTotalPrice()}";
            details.ForEach(od => result += "\r\n\t" + od);
            result += "\r\n-------------------------------------------------------------------------------------------------------------";
            return result;
        }
    }
}