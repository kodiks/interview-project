using System;
using System.Collections.Generic;
using Core.Model;

namespace Test
{
    public class OrderBuilder
    {
        private Order order;

        private OrderBuilder(Order order)
        {
            this.order = order;
            this.order.OrderDetails = new List<OrderDetail>();
        }

        public static OrderBuilder Create()
        {
            return new OrderBuilder(new Order());
        }

        public OrderBuilder AddDetail(int taxRate, int quantity, decimal unitPrice, int id = -1, int discountRate = 0)        {            var detail = new OrderDetail()            {                Id = id,                TaxRate = taxRate,                Quantity = quantity,                UnitPrice = unitPrice,                DiscountRate = discountRate            };
            detail.DiscountAmount = decimal.Round(unitPrice * discountRate / 100 * 2, 2);
            detail.TotalAmount = decimal.Round(unitPrice * quantity, 2);
            detail.TaxAmount = decimal.Round((detail.TotalAmount - detail.DiscountAmount) * detail.TaxRate / (100 + detail.TaxRate), 2);

            detail.GrossTotal = decimal.Round(detail.TotalAmount - detail.DiscountAmount - detail.TaxAmount, 2);            this.order.OrderDetails.Add(detail);            return this;        }

        public Order GetOrder()        {            return order;        }

    }
}
