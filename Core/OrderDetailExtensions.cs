using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class OrderDetailExtensions
    {
        /// <summary>
        /// Siparis detayi icin hesaplanilmasi gereken alanlari hesaplar.
        /// </summary>
        /// <param name="od"></param>
        /// <param name="digit">Virgulden sonraki basamak sayisi</param>
        public static void CalculateAndFixWith(this OrderDetail od, int digit = 2)
        {
            od.DiscountAmount = decimal.Round(od.UnitPrice * od.DiscountRate.Value / 100 * 2, digit);
            od.TotalAmount    = decimal.Round(od.UnitPrice * od.Quantity, 2);
            od.TaxAmount      = decimal.Round((od.TotalAmount - od.DiscountAmount) * od.TaxRate / (100 + od.TaxRate), 2);
            od.GrossTotal     = decimal.Round(od.TotalAmount - od.DiscountAmount - od.TaxAmount, 2);
        }
    }
}
