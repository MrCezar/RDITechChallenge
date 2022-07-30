namespace RDITechChallenge.Domain.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Token> Tokens { get; set; }
    }
}
