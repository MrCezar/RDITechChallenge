using RDITechChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace RDITechChallenge.Application.Tests.Fixtures
{
    public static class CardFixtures
    {
        public static Card GetTestCard() =>
            new Card()
            {
                CardId = 1,
                CardNumber = 1234567891234567,
                CustomerId = 1,
                CVV = 12345
            };

        public static Task<Card> GetTestTaskCard() =>
            Task.FromResult(new Card()
            {
                CardId = 1,
                CardNumber = 1234567891234567,
                CustomerId = 1,
                CVV = 12345
            });
    }
}
