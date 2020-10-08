using Core.Model;
using System;
using System.Linq;

namespace Core.Service
{
    public class OrderCalculatorService
    {
        public OrderCalculatorService()
        {
        }
        public void CalculateOrderTotal(ref Order order)
        {
            order.TotalAmount = decimal.Round(order.OrderDetails.Sum(a => a.UnitPrice * a.Quantity), 2);
        }
    }
}
