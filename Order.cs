using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace APN_Promise_app
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public decimal OrderTotal { get { return CalculatePrice(); } }
        private decimal CalculatePrice()
        {
            decimal sum = 0;
            foreach (var item in Items)
            {
                sum += item.Amount * item.Product.Price;
            }
            sum = CalculateDiscount(sum);
            return sum;
        }

        public void AddItemToOrder(Product product, int amount)
        {
            Items.Add(new OrderItem(product, amount));
        }
        public void RemoveItemFromOrder(int index, int amount)
        {
            if (Items[index].Amount == amount)
            {
                Items.RemoveAt(index);
            }
            else
            {
                Items[index].Amount -= amount;
            }
        }
        private decimal CalculateDiscount(decimal sum)
        {
            if (sum > 5000)
            {
                sum = sum * 0.95m;
            }
            if (Items.Count >= 3)
            {
                sum -= Items.Min(x => x.Product.Price) * 0.2m;
            }
            else if (Items.Count == 2)
            {
                sum -= Items.Min(x => x.Product.Price) * 0.1m;
            }
            return sum;
        }
    }
}