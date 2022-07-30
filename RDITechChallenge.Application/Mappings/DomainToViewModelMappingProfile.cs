using AutoMapper;
using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            //CreateMap<(Token token, Card card), TokenViewModel>()
            //    .ForMember(d => d.RegistrationDate, opt => opt.MapFrom(s => s.token.RegistrationDate))
            //    .ForMember(d => d.Token, opt => opt.MapFrom(s => s.token.TokenNumber))
            //    .ForMember(d => d.CardId, opt => opt.MapFrom(s => s.card.CardId));
            CreateMap<Token, TokenViewModel>()
                .ForMember(m => m.CardId, opt => opt.MapFrom(s => s.CardId))
                .ForMember(m => m.RegistrationDate, opt => opt.MapFrom(s => s.RegistrationDate))
                .ForMember(m => m.Token, opt => opt.MapFrom(s => s.TokenNumber));
        }
    }
}
