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
        public Order()
        {
            Items = new List<OrderItem>
            {
                new OrderItem(new Product("Laptop",  2500), 0),
                new OrderItem(new Product("Klawiatura", 120), 0),
                new OrderItem(new Product("Mysz", 90), 0),
                new OrderItem(new Product("Monitor", 1000),0),
                new OrderItem(new Product("Kaczka debugująca", 66),0)
            };
        }
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

        public void AddItemToOrder(int index, int amount)
        {
            Items[index].Amount += amount;
        }
        public void RemoveItemFromOrder(int index, int amount)
        {
            Items[index].Amount -= amount;
        }
        public bool CheckItemAmountToRemove(int index, int amount)
        {
            return Items[index].Amount >= amount;
        }
        private decimal CalculateDiscount(decimal sum)
        {
            int TotalItems = Items.Sum(x => x.Amount);
            if (sum > 5000)
            {
                sum = sum * 0.95m;
            }
            if (TotalItems >= 3)
            {
                sum -= Items.Min(x => x.Product.Price) * 0.2m;
            }
            else if (TotalItems == 2)
            {
                sum -= Items.Min(x => x.Product.Price) * 0.1m;
            }
            return sum;
        }
        public override string ToString()
        {
            string allProducts = "";
            foreach (OrderItem item in Items)
            {
                if (item.Amount > 0)
                    allProducts += $"{item.Product.Name}: {item.Amount}\n";
            }
            return allProducts;
        }
    }
}