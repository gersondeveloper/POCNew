using System;
using System.Collections.Generic;
using System.Text;

namespace POCOi.Domain.OrdersContext.Queries
{
    public class ListOrdersQueryResult
    {
        public int Order_Id { get; set; }
        public int Customer_Id { get; set; }
        public string Status { get; set; }
        public int Salesman_Id { get; set; }
        public DateTime Order_Date { get; set; }
    }
}
