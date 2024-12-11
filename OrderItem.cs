using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN_Promise_app
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }
        public OrderItem(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }
    }
}