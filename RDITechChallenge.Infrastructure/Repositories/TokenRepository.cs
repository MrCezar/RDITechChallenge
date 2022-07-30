using Microsoft.EntityFrameworkCore;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;
using RDITechChallenge.Infrastructure.Data;

namespace RDITechChallenge.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Token?> GetToken(long tokenNumber)
        {
            return await _context.Tokens.FirstOrDefaultAsync(t => t.TokenNumber == tokenNumber);
        }

        public async Task SaveToken(Token token)
        {
            _context.Tokens.Add(token);
            await _context.SaveChangesAsync();
        }
    }
}
