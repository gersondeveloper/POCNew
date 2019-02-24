using System;
using System.Collections.Generic;

namespace POCOiNew.Domain.OrderContext.Entities
{
    public class OrderItems
    {
        public OrderItems()
        {
            Products = new HashSet<Products>();
        }
        public int Order_Id { get; set; }
        public int Item_Id { get; set; }
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public double Unit_Price { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}