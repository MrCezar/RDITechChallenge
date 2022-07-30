using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Task SaveToken(Token token);
        Task<Token?> GetToken(long tokenNumber);
    }
}
