namespace TestApi.Database.Entities
{
    public class OrderEty
    {
        public int Id { get; set; }
        public int CustomerId {  get; set; }
        public DateTime CreateAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set;  }
        public DateTimeOffset? ReceivedAt { get; set; }
        public decimal Amount { get; set; }

        public CustomerEty? Customer { get; set; }
    }
}
