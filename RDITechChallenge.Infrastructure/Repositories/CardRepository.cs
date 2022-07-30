using Microsoft.EntityFrameworkCore;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;
using RDITechChallenge.Infrastructure.Data;

namespace RDITechChallenge.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Card?> GetCardByCardId(int cardId)
        {
            return await _context.Cards.FindAsync(cardId);
        }

        public async Task<Card?> GetCardByCardNumber(Card card)
        {
            return await _context.Cards.FirstOrDefaultAsync(c =>
                c.CardNumber == card.CardNumber
                && c.CVV == card.CVV
            );
        }

        public async Task SaveCardAsync(Card card)
        {
            _context.Add(card);
            await _context.SaveChangesAsync();
        }
    }
}
