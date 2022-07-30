using AutoMapper;
using RDITechChallenge.Application.Exceptions;
using RDITechChallenge.Application.Interfaces;
using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;
using RDITechChallenge.Domain.Interfaces;

namespace RDITechChallenge.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ITokenService _tokenService;
        private ICardRepository _cardRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public CardService(
            ITokenService tokenService,
            ICardRepository cardRepository,
            ICustomerRepository customerRepository,
            ITokenRepository tokenRepository,
            IMapper mapper
            )
        {
            _tokenService = tokenService;
            _cardRepository = cardRepository;
            _customerRepository = customerRepository;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<TokenViewModel> PostCard(CardViewModel cardViewModel)
        {
            var mapCard = _mapper.Map<Card>(cardViewModel);

            var dbCustomer = await _customerRepository.GetCustomerById(cardViewModel.CustomerId);
            if (dbCustomer is null)
                throw new CustomerNotFoundException("Customer not found");

            var dbCard = await _cardRepository.GetCardByCardNumber(mapCard);
            if (dbCard is null)
                await _cardRepository.SaveCardAsync(mapCard);

            var generatedToken = _tokenService.GenerateToken(mapCard);
            await _tokenRepository.SaveToken(generatedToken);

            return _mapper.Map<TokenViewModel>(generatedToken);
        }
    }
}
