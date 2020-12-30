using System;
using System.Collections.Generic;

namespace eShop_Backend.Core.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
