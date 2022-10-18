using System.Collections.Generic;

namespace Lab_KPZ_3.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }

        public virtual OrderStatus Status { get; set; }
        public virtual User User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
