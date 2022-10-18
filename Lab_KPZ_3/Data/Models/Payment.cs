namespace Lab_KPZ_3.Data.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Provider { get; set; }

        public virtual Order Order { get; set; }
    }
}
