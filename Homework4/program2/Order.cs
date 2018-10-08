using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Order
    {
        public string orderNumber { get; set; }
        public string goodName { get; set; }
        public string guestName { get; set; }
        public Order(string orderN, string goodN, string guestN)
        {
            orderNumber = orderN;
            goodName = goodN;
            guestName = guestN;
        }

    }
}
