using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Domain.Interfaces
{
    public interface ICardRepository
    {
        Task<Card?> GetCardByCardNumber(Card card);

        Task<Card?> GetCardByCardId(int cardId);

        Task SaveCardAsync(Card card);
    }
}
