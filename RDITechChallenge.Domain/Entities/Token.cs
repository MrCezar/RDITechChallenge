namespace RDITechChallenge.Domain.Entities
{
    public class Token
    {
        public int TokenId { get; set; }
        public long TokenNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
