using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Customer
    {
      
        public uint Id { get; set; }
  
        public string Name { get; set; }

        public Customer(uint id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return $"CustomerId:{Id}, CustomerName:{Name}";
        }

    }
}
