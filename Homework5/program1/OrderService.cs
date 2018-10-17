using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 在示例代码的基础上添加了  方法  QueryByAmount
 用来 查询  订单金额大于传入参数的订单
 
     */
namespace program1
{
    class OrderService
    {

        private Dictionary<uint, Order> orderDict;
    
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }
        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }     
        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }
        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }
        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values)
            {
                foreach (OrderDetail detail in order.Details)
                {
                    if (detail.Goods.Name == goodsName)
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
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }
        public List<Order> QueryByOrderID(string orderId)
        {
            uint unit1 = Convert.ToUInt32(orderId);
            var query = orderDict.Values
                .Where(order => order.Id == unit1);
            return query.ToList();
        }
        //查询金额大于传入参数的订单
        public List<Order> QueryByAmount(double Amount)
        {
            var query = orderDict.Values
                .Where(order => order.Amount >= Amount);
            return query.ToList();
        }

    }
}
