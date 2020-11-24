using System;
using System.Collections.Generic;

#nullable disable

namespace eShop_Backend.Models
{
    public partial class Product
    {
        public Product()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ShortDesc { get; set; }
        public int? CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
