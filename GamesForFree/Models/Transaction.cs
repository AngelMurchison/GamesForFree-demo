namespace GamesForFree.Models
{
    public class Transaction : BaseEntity
    {
        public int VideoGameId { get; set; }
        public int CustomerId { get; set; }
        public decimal GamePointsExchanged { get; set; }

        public virtual VideoGame VideoGame { get; set; }
        public virtual User Customer { get; set; }
    }
}
