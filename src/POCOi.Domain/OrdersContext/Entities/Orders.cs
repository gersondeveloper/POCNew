using System;
using System.Collections.Generic;

namespace POCOiNew.Domain.OrderContext.Entities
{
    public class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Order_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Status { get; set; }
        public int Salesman_Id { get; set; }
        public DateTime Order_Date { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }

    }
}