using AutoMapper;
using RDITechChallenge.Application.ViewModels;
using RDITechChallenge.Domain.Entities;

namespace RDITechChallenge.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CardViewModel, Card>();
            CreateMap<CardViewModel, Customer>();

            CreateMap<CardTokenViewModel, Token>();
            CreateMap<CardTokenViewModel, Card>();
        }
    }
}
