using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN_Promise_app
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}