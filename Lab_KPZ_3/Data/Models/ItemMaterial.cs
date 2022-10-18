using System.Collections.Generic;

namespace Lab_KPZ_3.Data.Models
{
    public partial class ItemMaterial
    {
        public ItemMaterial()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
