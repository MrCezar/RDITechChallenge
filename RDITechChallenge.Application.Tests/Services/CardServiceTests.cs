using AutoMapper;
using FluentAssertions;
using Moq;
using RDITechChallenge.Application.Interfaces;
using RDITechChallenge.Application.Mappings;
using RDITechChallenge.Application.Services;
using RDITechChallenge.Application.Tests.Fixtures;
using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;
using Xunit;

namespace RDITechChallenge.Application.Tests.Services
{
    public class CardServiceTests
    {
        private readonly CardService _sut;
        private readonly Mock<ITokenService> _tokenService = new Mock<ITokenService>();
        private readonly Mock<ICardRepository> _cardRepository = new Mock<ICardRepository>();
        private readonly Mock<ICustomerRepository> _customerRepository = new Mock<ICustomerRepository>();
        private readonly Mock<ITokenRepository> _tokenRepository = new Mock<ITokenRepository>();
        private IMapper _mapper;

        public CardServiceTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                cfg.AddProfile(new DomainToViewModelMappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            _sut = new CardService(
                _tokenService.Object,
                _cardRepository.Object,
                _customerRepository.Object,
                _tokenRepository.Object,
                _mapper
                );
        }

        [Fact]
        public async void PostCard_WhenCalled_ReturnsValidTokenViewModelObject()
        {
            // Arrange
            _tokenService
                .Setup(x => x.GenerateToken(It.IsAny<Card>()))
                .Returns(TokenFixtures.GetTestToken());

            _customerRepository
                .Setup(x => x.GetCustomerById(1))
                .Returns(CustomerFixtures.GetTestTaskCustomer());

            var expected = new TokenViewModel
            {
                CardId = 1,
                RegistrationDate = System.DateTime.Parse(System.DateTime.Now.ToLongDateString()),
                Token = 7456
            };

            // Act
            var actual = await _sut.PostCard(CardViewModelFixtures.GetTestCardViewModel());

            // Assert
            Assert.True(actual != null);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}