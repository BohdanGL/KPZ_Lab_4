namespace Lab_KPZ_3.Data.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public virtual User User { get; set; }
    }
}
