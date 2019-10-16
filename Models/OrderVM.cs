using System;

namespace MultiLocales.Models
{
    public class OrderVM
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public decimal? Freight { get; set; }
        public bool IsVip { get; set; }

        public OrderVM()
        {
        }
    }
}
