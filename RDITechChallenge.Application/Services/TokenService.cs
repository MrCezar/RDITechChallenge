using RDITechChallenge.Application.Interfaces;
using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;

namespace RDITechChallenge.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ICardRepository _cardRepository;

        public TokenService(
            ITokenRepository tokenRepository,
            ICardRepository cardRepository)
        {
            _tokenRepository = tokenRepository;
            _cardRepository = cardRepository;
        }

        public Token GenerateToken(Card card)
        {
            var lastFourCardDigits = card.CardNumber % 10000;
            var lastFourCardDigitsArray = lastFourCardDigits
                .ToString()
                .ToArray();

            for (int i = 0; i < card.CVV; i++)
            {
                lastFourCardDigitsArray = PerformRightCircularRotation(lastFourCardDigitsArray);
            }

            return new Token()
            {
                Card = card,
                RegistrationDate = DateTime.Now,
                TokenNumber = long.Parse(new string(lastFourCardDigitsArray)),
            };
        }

        public async Task<bool> ValidateToken(CardTokenViewModel cardToken)
        {
            var token = await _tokenRepository.GetToken(cardToken.Token);

            if (token is null)
                return false;

            var hourDifference = (DateTime.Now - token.RegistrationDate).TotalMinutes;
            if (hourDifference > 30)
                return false;

            var card = await _cardRepository.GetCardByCardId(cardToken.CardId);

            if (card is null)
                return false;

            if (card.CustomerId != cardToken.CustomerId)
                return false;

            var newToken = GenerateToken(card);
            if (token.TokenNumber != newToken.TokenNumber)
                return false;

            return true;
        }

        private char[] PerformRightCircularRotation(char[] array)
        {
            int lastIndex = array.Length - 1;
            char temp = array[lastIndex];
            for (int j = lastIndex; j > 0; j--)
            {
                array[j] = array[j - 1];
            }
            array[0] = temp;

            return array;
        }
    }
}
