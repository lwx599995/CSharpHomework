using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class OrderServiceTests
    {
        private OrderService CreateService()
        {
            return new OrderService();
        }
        [TestMethod]
        public void AddOrder_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            bool flag = unitUnderTest.AddOrder(
                order);
            bool flag1 = unitUnderTest.AddOrder(
                order);
            Assert.IsFalse(flag1);//成功的测试（对重复添加订单报错）
        }

        [TestMethod]
        public void RemoveOrder_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            string orderId = "id";
            Order order = new Order(orderId, "customer");
            unitUnderTest.AddOrder(
                order);
            bool flag = unitUnderTest.RemoveOrder(
                orderId);
            Assert.IsTrue(flag);//成功的测试，移除已有订单
        }

        [TestMethod]
        public void QueryAllOrders_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            unitUnderTest.AddOrder(
                order);
            var result = unitUnderTest.QueryAllOrders();
            var ods = unitUnderTest.orderDict.Values.ToList();
            Assert.AreEqual(result, ods);//失败的测试
        }
        [TestMethod]
        public void GetById_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            unitUnderTest.AddOrder(
                order);
            string orderId = "id";
            var result = unitUnderTest.GetById(
                orderId);
            var expect = unitUnderTest.orderDict[orderId];
            Assert.AreEqual(result, expect);//成功的测试，按订单号查询
        }

        [TestMethod]
        public void QueryByGoodsName_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            Goods apple = new Goods("food_apple_360", "apple", 5.59);
            OrderDetail orderDetails = new OrderDetail("Mon100", apple, 1780);
            order.AddDetails(orderDetails);
            unitUnderTest.AddOrder(
                order);
            string goodsName = "apple";
            var result = unitUnderTest.QueryByGoodsName(
                goodsName);
            var wrong = "unexpect";
            Assert.AreEqual(result, wrong);//失败的测试（错误的预期结果）
        }
        [TestMethod]
        public void QueryByCustomerName_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer"); 
            unitUnderTest.AddOrder(
                order);
            string Name = "customer";
            var result = unitUnderTest.QueryByCustomerName(
                Name);
            var wrong = "unexpect";
            Assert.AreEqual(result, wrong);//失败的测试（错误的预期结果）
        }

        [TestMethod]
        public void QueryByTotalPrice_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            Goods apple = new Goods("food_apple_360", "apple", 5.59);
            OrderDetail orderDetails = new OrderDetail("Mon100", apple, 1780);
            order.AddDetails(orderDetails);
            unitUnderTest.AddOrder(
                order);
            double price = 1000;
            var result = unitUnderTest.QueryByTotalPrice(
                price);
            var wrong = "unexpect";
            Assert.AreEqual(result, wrong);//失败的测试（错误的预期结果）
        }

        [TestMethod]
        public void Export_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            Order order = new Order("id", "customer");
            unitUnderTest.AddOrder(
                order);
            string xmlFileName = "xmlFileName";
            bool flag = unitUnderTest.Export(
                xmlFileName);
            Assert.IsTrue(flag);//成功的测试，XML序列化订单
        }

        [TestMethod]
        public void Import_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            string xmlFileName = "xmlFileName";
            bool flag = unitUnderTest.Import(
                     xmlFileName);
            Assert.IsTrue(flag);//成功的测试，从XML文件读取订单
        }
    }
}
