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
            // OrderDetail ekleme aninda hesaplatmak daha dogru geldi sonradan.
            // order.TotalAmount = decimal.Round(order.OrderDetails.Sum(a => a.UnitPrice * a.Quantity), 2);
            order.TotalDiscount = order.OrderDetails.Sum(a => a.DiscountAmount);
            order.TotalAmount = order.OrderDetails.Sum(a => a.TotalAmount - a.DiscountAmount);
            order.TaxAmount = order.OrderDetails.Sum(a => a.TaxAmount);
            order.GrossAmount = order.TotalAmount - order.TaxAmount;
        }
    }
}
