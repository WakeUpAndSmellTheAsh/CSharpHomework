using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 在示例代码的基础上添加了  Amount 
 用来存放  某个订单中所有货物的总价格
 
     */
namespace program1
{
    class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();
       public double Amount;
        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(uint orderId, Customer customer)
        {
            Id = orderId;
            Customer = customer;

        }

        /// <summary>
        /// order id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }
     //   public Customer Customer { get; set; }


        public List<OrderDetail> Details
        {
            get => this.details;
        }

       
        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
            Amount += orderDetail.Quantity * orderDetail.Goods.Price;
        }

  


        public override string ToString()
        {
            string result = "---------------------------------------------------------------------------\n";
            result += $"orderId:{Id}, customer:({Customer}" + $", Amount:{Amount}) ";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n---------------------------------------------------------------------------";
            return result;
        }
    }
}
