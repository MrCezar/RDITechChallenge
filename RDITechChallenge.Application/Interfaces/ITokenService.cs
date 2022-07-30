using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Application.Interfaces
{
    public interface ITokenService
    {
        Token GenerateToken(Card card);
        Task<bool> ValidateToken(CardTokenViewModel cardToken);
    }
}
