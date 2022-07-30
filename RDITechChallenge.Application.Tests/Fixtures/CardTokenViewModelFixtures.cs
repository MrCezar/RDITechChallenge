using RDITechChallenge.Application.ViewModels;

namespace RDITechChallenge.Application.Tests.Fixtures
{
    public static class CardTokenViewModelFixtures
    {
        public static CardTokenViewModel GetTestCardViewModel() =>
            new CardTokenViewModel()
            {
                CardId = 1,
                CustomerId = 1,
                CVV = 12345,
                Token = 7456
            };
    }
}
