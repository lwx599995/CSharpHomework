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
            Assert.IsFalse(flag1);//�ɹ��Ĳ��ԣ����ظ���Ӷ�������
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
            Assert.IsTrue(flag);//�ɹ��Ĳ��ԣ��Ƴ����ж���
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
            Assert.AreEqual(result, ods);//ʧ�ܵĲ���
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
            Assert.AreEqual(result, expect);//�ɹ��Ĳ��ԣ��������Ų�ѯ
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
            Assert.AreEqual(result, wrong);//ʧ�ܵĲ��ԣ������Ԥ�ڽ����
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
            Assert.AreEqual(result, wrong);//ʧ�ܵĲ��ԣ������Ԥ�ڽ����
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
            Assert.AreEqual(result, wrong);//ʧ�ܵĲ��ԣ������Ԥ�ڽ����
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
            Assert.IsTrue(flag);//�ɹ��Ĳ��ԣ�XML���л�����
        }

        [TestMethod]
        public void Import_StateUnderTest_ExpectedBehavior()
        {
            var unitUnderTest = CreateService();
            string xmlFileName = "xmlFileName";
            bool flag = unitUnderTest.Import(
                     xmlFileName);
            Assert.IsTrue(flag);//�ɹ��Ĳ��ԣ���XML�ļ���ȡ����
        }
    }
}
