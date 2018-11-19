using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;



namespace program1
{
    [Serializable]
    public class OrderService
    {

        public List<Order> orderDict = new List<Order>();
        public void AddOrder(Order order) => orderDict.Add(order);


        public List<Order> QueryAllOrders()
        {
            return orderDict.ToList();
        }
        public Order GetById(int orderId)
        {
            return orderDict[orderId];
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict)
            {
                foreach (OrderDetail detail in order.Details)
                {
                    if (detail.Goods.GoodName == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict
                .Where(order => order.OrderCustomer == customerName);
            return query.ToList();
        }
        public List<Order> QueryByOrderID(string orderId)
        {
            uint unit1 = Convert.ToUInt32(orderId);
            var query = orderDict
                .Where(order => order.OrderId == unit1);
            return query.ToList();
        }
        //查询金额大于传入参数的订单
        public List<Order> QueryByAmount(double Amount)
        {
            var query = orderDict
                .Where(order => order.Amount >= Amount);
            return query.ToList();
        }
        public OrderService() { }
        public void Export(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            string xmlFileName = path;
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            xmlSerializer.Serialize(fs, this);
            fs.Close();
        }
        public static OrderService Import(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(OrderService));
            OrderService OrderService = (OrderService)xmlSerializer.Deserialize(file);
            file.Close();
            return OrderService;
        }

    }
}


