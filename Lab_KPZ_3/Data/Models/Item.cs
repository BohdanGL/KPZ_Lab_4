using System.Collections.Generic;

namespace Lab_KPZ_3.Data.Models
{
    public partial class Item
    {
        public Item()
        {
            CartItems = new HashSet<CartItem>();
            Feedbacks = new HashSet<Feedback>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string Size { get; set; }
        public int TypeId { get; set; }
        public int MaterialId { get; set; }
        public int Quantity { get; set; }

        public virtual ItemMaterial Material { get; set; }
        public virtual ItemType Type { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
