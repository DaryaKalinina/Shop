using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class OrderItem
    {
        public OrderItem()
        { }

        public OrderItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }
       // public bool IsItPaid { get; set; }
    }
}