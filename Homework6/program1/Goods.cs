using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Goods
    {
        public double price;
        public Goods() { }
        public Goods(int id, string name, double value)
        {
            Id = id;
            Name = name;
            Price = value;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("value must >= 0!");
                price = value;
            }
        }

        public override string ToString()
        {
            return $"GoodId:{Id}, GoodName:{Name}, Value:{Price}";
        }
    }
}
