using RDITechChallenge.Application.ViewModels;

namespace RDITechChallenge.Application.Tests.Fixtures
{
    public static class CardViewModelFixtures
    {
        public static CardViewModel GetTestCardViewModel() =>
            new CardViewModel
            {
                CardNumber = 1234567891234567,
                CustomerId = 1,
                CVV = 12345
            };
    }
}
