﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ordertest
{
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService { 

        private Dictionary<ulong, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderDict = new Dictionary<ulong, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public void AddOrder(Order order) {
            using (var db = new OrderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                db.Entry(order.Customer).State = EntityState.Modified;
                order.Details.ForEach(
                    detial => db.Entry(detial).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(ulong orderId){
            using (var db = new OrderDB())
            {
                var order = db.Order.Include("Details").SingleOrDefault(o => o.Id == orderId);
                db.OrderDetail.RemoveRange(order.Details);
                db.Customer.Remove(order.Customer);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }
        
        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders() {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Detials").ToList<Order>();
            }
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(ulong orderId) {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Detials").
                  SingleOrDefault(o => o.Id == orderId);
            }
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName) {
            using (var db = new OrderDB())
            {
                var query = db.Order.Include("Detials")
                  .Where(o => o.Details.Where(
                    item => item.Goods.gName.Equals(goodsName)).Count() > 0);
                return query.ToList<Order>();
            }
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName) {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Detials")
                  .Where(o => o.Customer.Name.Equals(customerName)).ToList<Order>();
            }
        }

        public List<Order> QueryByPrice(double price)
        {
            using (var db = new OrderDB())
            {
                return db.Order.Include("Detials")
                  .Where(order => order.Amount > price).ToList<Order>();
            }
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(ulong orderId, Customer newCustomer) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict[orderId].Customer = newCustomer;
            } else {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }

        /// <summary>
        /// Store the order object to file orders.xml
        /// </summary>
        public string Export()
        {
            DateTime time = System.DateTime.Now;
            string fileName = "orders_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".xml";
            Export(fileName);
            return fileName;
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, orderDict.Values.ToList());
            }
        }

        /// <summary>
        /// Store the order object to file orders.html
        /// </summary>
        public string Export2html()
        {
            DateTime time = System.DateTime.Now;
            string htmlfilename = "orders_" + time.Year + "_" + time.Month
                + "_" + time.Day + "_" + time.Hour + "_" + time.Minute
                + "_" + time.Second + ".html";
            Export2html(htmlfilename);
            return htmlfilename;
        }
        public void Export2html(String htmlfilename)
        {
            try
            {
                String xmlfileName = "temp.xml";
                XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
                using (FileStream fs = new FileStream(xmlfileName, FileMode.Create))
                {
                    xs.Serialize(fs, orderDict.Values.ToList());
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlfileName);

                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@"..\..\1.xslt");

                FileStream outFileStream = File.OpenWrite(htmlfilename);
                XmlTextWriter writer =
                    new XmlTextWriter(outFileStream, Encoding.UTF8);
                xt.Transform(nav, null, writer);
                outFileStream.Close();

            }
            catch (XmlException e)
            {
                Console.WriteLine("XmlException：" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("XsltException：" + e.ToString());
            }
        }

        /// <summary>
        /// import the orders object from xml file in path
        /// return the order imported to service obj
        /// </summary>
        public List<Order> Import(string path)
        {
            if (Path.GetExtension(path) != ".xml")
                throw new ArgumentException("It isn't a xml file!");
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            List<Order> result = new List<Order>();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order =>
                {
                    using (var db = new OrderDB())
                    {
                        db.Order.Add(order);
                        db.SaveChanges();
                    }
                });
            }
            return result;
        }

        /*other edit function with write in the future.*/
    }
}
