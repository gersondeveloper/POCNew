using System;
using System.Collections.Generic;

namespace POCOiNew.Domain.OrderContext.Entities
{
    public class Products
    {

        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public double Standard_Cost { get; set; }
        public double List_Price { get; set; }
        public int Category_Id { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}