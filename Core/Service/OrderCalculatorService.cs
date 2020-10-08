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
            // Hesaplama islemlerini OrderDetail sinifina mudahale etmeden yaptirmak istedim.
            // Bu nedenle de hesaplama ve round islemleri icin bir Extension metod olusturdum. Ve servisin hesaplatma metodunda(burada) cagirmaya karar verdim.
            foreach (var od in order.OrderDetails)
            {
                od.CalculateAndFixWith();
            }
            order.TotalDiscount = order.OrderDetails.Sum(a => a.DiscountAmount);
            order.TotalAmount = order.OrderDetails.Sum(a => a.TotalAmount - a.DiscountAmount);
            order.TaxAmount = order.OrderDetails.Sum(a => a.TaxAmount);
            order.GrossAmount = order.TotalAmount - order.TaxAmount;
        }
    }
}
