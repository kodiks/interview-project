using System.Linq;
using Core.Service;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]        public void OrderTotalAmount()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                 .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.TotalAmount == (decimal)20);        }

        [Test]        public void OrderTaxAmount()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                  .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.TaxAmount == (decimal)1.48);        }

        [Test]        public void OrderGrossAmount()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                 .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.GrossAmount == (decimal)18.52);            Assert.IsTrue(order.TotalDiscount == (decimal)0);        }

        [Test]        public void OrderDetailFreeOfCharge()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                 .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1, 100)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.TotalDiscount == (decimal)10);            Assert.IsTrue(order.TotalAmount == (decimal)10);            Assert.IsTrue(order.OrderDetails.First().DiscountAmount == (decimal)10);        }

        [Test]        public void OrderDetailPartialDiscountRate()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                 .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1, 50)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.TotalDiscount == (decimal)5);            Assert.IsTrue(order.TotalAmount == (decimal)15);            Assert.IsTrue(order.OrderDetails.First().DiscountAmount == (decimal)5);        }

        [Test]        public void OrderDetailGrossAmount()        {            var service = new OrderCalculatorService();            var order = OrderBuilder.Create()                 .AddDetail(taxRate: 8, quantity: 2, unitPrice: 5, id: 1, 50)                 .AddDetail(taxRate: 8, quantity: 1, unitPrice: 10, id: 2)                 .GetOrder();            service.CalculateOrderTotal(ref order);            Assert.IsTrue(order.OrderDetails.First().GrossTotal == (decimal)4.63);            Assert.IsTrue(order.OrderDetails.First().TaxAmount == (decimal)0.37);            Assert.IsTrue(order.OrderDetails.First().TotalAmount == (decimal)5);
            //Assert.IsTrue(order.OrderDetails.First().TotalAmount == (decimal)10);
        }
    }
}