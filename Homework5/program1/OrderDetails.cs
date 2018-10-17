using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{
    class OrderDetail
    {
        public OrderDetail(string id, Goods goods, uint quantity)
        {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }
        public string Id { get; set; }
        public Goods Goods { get; set; }
        public uint Quantity { get; set; }
        public double goodsPrice
        {
            get { return Goods.Price * Quantity; }
        }
        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Id == detail.Goods.Id &&
                Quantity == detail.Quantity;
        }
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}" + $", goodsPrice:{goodsPrice}";
            return result;
        }
    }
}