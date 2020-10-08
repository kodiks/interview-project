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
                        this.order.OrderDetails.Add(detail);            return this;        }

        public Order GetOrder()        {            return order;        }

    }
}
