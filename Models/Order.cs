using GridShared.DataAnnotations;
using GridShared.Sorting;
using System;
using System.ComponentModel.DataAnnotations;

namespace MultiLocales.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int OrderID { get; set; }
        [Required]
        public string CustomerID { get; set; }
        [GridColumn(Title = "Date", Width = "120px", Format = "{0:yyyy-MM-dd}", SortEnabled = true, FilterEnabled = true, SortInitialDirection = GridSortDirection.Ascending)]
        public DateTime? OrderDate { get; set; }
        [GridColumn(Title = "Freight", Width = "120px", SortEnabled = true, FilterEnabled = true)]
        public decimal? Freight { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
