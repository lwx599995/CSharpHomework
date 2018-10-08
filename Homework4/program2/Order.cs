using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Details;
namespace Orders
{
    class Order: OrderDetails
    {
        public Order(string ON,string GN,string CN,int GC)
        {
            this.OrderNumber = ON;
            this.GoodsName = GN;
            this.ClientName = CN;
            this.GoodsCount = GC;
        }
    }
}
