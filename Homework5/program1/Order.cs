using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();
        public Order(string orderId, string customer)
        {
            Id = orderId;
            Customer = customer;
        }
        public string Id { get; set; }
        public string Customer { get; set; }
        public List<OrderDetail> Details
        {
            get => this.details;
        }
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
            string result = "-------------------------------------------------------------------------------------------------------------\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n-------------------------------------------------------------------------------------------------------------";
            return result;
        }
    }
}