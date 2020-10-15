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
        /// <summary>
        /// We did all the calculations in the order detail class
        /// Rounded 2 digit
        /// </summary>
        /// <param name="order"></param>
        public void CalculateOrderTotal(ref Order order)
        {

            foreach (var item in order.OrderDetails)
            {
                item.DiscountAmount = Decimal.Round(((decimal)item.Quantity * item.UnitPrice) * ((decimal)item.DiscountRate.Value / (decimal)100), 2);
                item.TotalAmount = Decimal.Round(((decimal)item.Quantity * item.UnitPrice) - item.DiscountAmount, 2);
                item.TaxAmount = Decimal.Round(item.TotalAmount - (item.TotalAmount / (1 + ((decimal)item.TaxRate / (decimal)100))), 2);
                item.GrossTotal = Decimal.Round(item.TotalAmount - item.TaxAmount, 2);
            }
            order.TotalDiscount = order.OrderDetails.Sum(x => x.DiscountAmount);
            order.TotalAmount = order.OrderDetails.Sum(x => x.TotalAmount);
            order.TaxAmount = order.OrderDetails.Sum(x => x.TaxAmount);
            order.GrossAmount = order.OrderDetails.Sum(x => x.GrossTotal);
        }

    }
}
