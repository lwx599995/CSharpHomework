using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orders;
using My_Exception;
namespace Order_Service
{
    class OrderService
    {
        static List<string> OrderNumbers = new List<string>();
        static List<string> GoodsName = new List<string>();
        static List<string> ClientName = new List<string>();
        static List<int> GoodsCount = new List<int>();
        //初始化订单
        public static void InitOrder()
        {

            Order[] Orders =
            {
            new Order("a1","apple","张三",10),
            new Order("b2","banana","李四",8),
            new Order("c3","pear","王二",6),
            };
            foreach (Order r in Orders)
            {
                OrderNumbers.Add(r.OrderNumber);
                GoodsName.Add(r.GoodsName);
                ClientName.Add(r.ClientName);
                GoodsCount.Add(r.GoodsCount);
            }
        }
        //展示订单
        public static void Show()
        {
            Console.Write("订单编号：");
            for (int i = 0; i < OrderNumbers.Count; i++)
                Console.Write("\t" + OrderNumbers[i]);
            Console.Write("\n商品名称：");
            for (int i = 0; i < GoodsName.Count; i++)
                Console.Write("\t" + GoodsName[i]);
            Console.Write("\n客户姓名：");
            for (int i = 0; i < ClientName.Count; i++)
                Console.Write("\t" + ClientName[i]);
            Console.Write("\n商品数量：");
            for (int i = 0; i < GoodsCount.Count; i++)
                Console.Write("\t" + GoodsCount[i]);
            Console.Write("\n\n");
        }
        //添加订单
        public static void Add(string ON, string GN, string CN, int GC)
        {
            Order add = new Order(ON,  GN,  CN,  GC);
            OrderNumbers.Add(add.OrderNumber);
            GoodsName.Add(add.GoodsName);
            ClientName.Add(add.ClientName);
            GoodsCount.Add(add.GoodsCount);
        }
        //删除订单
        public static void Delete(int i)
        {
            if (i < 0 || i >= OrderNumbers.Count)
                throw new DeleteException("要删除的订单不存在，请检查");
            OrderNumbers.RemoveAt(i);
            GoodsName.RemoveAt(i);
            ClientName.RemoveAt(i);
            GoodsCount.RemoveAt(i);
        }
        //修改订单
        public static void Modify(int i, string ON, string GN, string CN, int GC)
        {
            if (i < 0 || i >= OrderNumbers.Count)
                throw new ModifyException("要修改的订单不存在，请检查");
            OrderNumbers[i] = ON;
            GoodsName[i] = GN;
            ClientName[i] = CN;
            GoodsCount[i] = GC;
        }
        //查找订单 按订单号、商品名、客户名
        public static void ReferByOrderNumbers(string ON)
        {
            int i;
            for ( i = 0; i < OrderNumbers.Count; i++)
            {
                if (ON == OrderNumbers[i])
                    Console.Write($"查找成功，该订单在第{i + 1}列\n");
            }
        }
        public static void ReferByGoodsName(string GN)
        {
            int i;
            for ( i = 0; i < GoodsName.Count; i++)
                if (GN == GoodsName[i])
                    Console.Write($"查找成功，该订单在第{i+1}列\n");
        }
        public static void ReferByClientName(string CN)
        {
            int i;
            for ( i = 0; i < ClientName.Count; i++)
                if (CN == ClientName[i])
                    Console.Write($"查找成功，该订单在第{i+1}列\n");
        }

    }
}
