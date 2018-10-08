using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Details
{
    class OrderDetails
    {
        public string OrderNumber { set; get; }
        public string GoodsName { set; get; }
        public string ClientName { set; get; }
        public int GoodsCount { set; get; }        //订单号、商品名称、客户名称、商品数量
    }
}
