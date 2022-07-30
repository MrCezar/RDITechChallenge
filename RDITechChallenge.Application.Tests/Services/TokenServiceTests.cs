using FluentAssertions;
using Moq;
using RDITechChallenge.Application.Services;
using RDITechChallenge.Application.Tests.Fixtures;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;
using Xunit;

namespace RDITechChallenge.Application.Tests.Services
{
    public class TokenServiceTests
    {
        private readonly TokenService _sut;
        private readonly Mock<ITokenRepository> _tokenRepository = new Mock<ITokenRepository>();
        private readonly Mock<ICardRepository> _cardRepository = new Mock<ICardRepository>();

        public TokenServiceTests()
        {
            _sut = new TokenService(
                _tokenRepository.Object,
                _cardRepository.Object
            );
        }

        [Fact]
        public void GenerateToken_WhenCalled_ReturnsValidToken()
        {
            // Arrange
            var expected = new Token()
            {
                Card = CardFixtures.GetTestCard(),
                CardId = 0,
                RegistrationDate = System.DateTime.Now,
                TokenNumber = 7456
            };

            // Act
            var actual = _sut.GenerateToken(CardFixtures.GetTestCard());

            // Assert
            Assert.True(actual != null);
            actual.Should().BeEquivalentTo(expected, e => e.Excluding(s => s.RegistrationDate));
        }

        [Fact]
        public async void ValidateToken_WhenCalled_ReturnsIfTokenIsValid()
        {
            // Arrange
            _tokenRepository
                .Setup(x => x.GetToken(CardTokenViewModelFixtures.GetTestCardViewModel().Token))
                .Returns(TokenFixtures.GetTestTaskToken());

            _cardRepository
                .Setup(x => x.GetCardByCardId(CardFixtures.GetTestCard().CardId))
                .Returns(CardFixtures.GetTestTaskCard());

            var expected = true;

            // Act
            var actual = await _sut.ValidateToken(CardTokenViewModelFixtures.GetTestCardViewModel());

            // Assert
            actual.Should().Be(expected);
        }
    }
}
