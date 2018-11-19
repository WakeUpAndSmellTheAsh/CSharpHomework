﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Runtime.Serialization;

using System.Xml.Serialization;
/*
 在示例代码的基础上添加了  Amount 
 用来存放  某个订单中所有货物的总价格
 
     */
namespace program1
{
    [Serializable]
    public class Order
    {

        public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();

        public Order() { }
        public Order(int Id, String Customer)
        {
            this.OrderId = Id;
            this.OrderCustomer = Customer;
        }
        public int OrderId { get; set; }
        public String OrderCustomer { get; set; }
        public double Amount { get; set; }


        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            Details.Add(orderDetail);
            Amount += orderDetail.amount;
        }
        public override string ToString()
        {
            string result = "\n";
            result += $"orderId:{OrderId}, customer:({OrderCustomer}" + $", Amount:{Amount}) ";
            Details.ForEach(od => result += "\n\t" + od);
            result += "\n---------------------------------------------------------------------------";
            return result;
        }
    }
}

//namespace program1
//{
//    [Serializable]
//    public class Order
//    {
//        public List<OrderDetail> details = new List<OrderDetail>();
//        public double Amount;
//        public Order() { }
//        public Order(int Id,Customer Customer)
//        {
//            this.OrderId = Id;
//            this.OrderCustomer = Customer;
//        }    
//        public int OrderId { get; set; }     
//        public Customer OrderCustomer { get; set; }
//        public List<OrderDetail> Details
//        {
//            get => this.details;
//        }

//        public void AddDetails(OrderDetail orderDetail)
//        {
//            if (this.Details.Contains(orderDetail))
//            {
//                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
//            }
//            details.Add(orderDetail);
//            Amount += orderDetail.Quantity * orderDetail.Goods.Price;
//        }
//        public override string ToString()
//        {
//            string result = "---------------------------------------------------------------------------\n";
//            result += $"orderId:{OrderId}, customer:({OrderCustomer}" + $", Amount:{Amount}) ";
//            details.ForEach(od => result += "\n\t" + od);
//            result += "\n---------------------------------------------------------------------------";
//            return result;
//        }
//    }
//}
