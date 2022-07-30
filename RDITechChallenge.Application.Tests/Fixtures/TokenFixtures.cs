using RDITechChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace RDITechChallenge.Application.Tests.Fixtures
{
    public static class TokenFixtures
    {
        public static Token GetTestToken() =>
            new Token()
            {
                RegistrationDate = System.DateTime.Parse(System.DateTime.Now.ToLongDateString()),
                TokenId = 1,
                TokenNumber = 7456,
                CardId = 1
            };

        public static Task<Token> GetTestTaskToken() =>
           Task.FromResult(new Token()
           {
               RegistrationDate = System.DateTime.Now,
               TokenId = 1,
               TokenNumber = 7456,
               CardId = 1
           });
    }
}
