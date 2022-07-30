using RDITechChallenge.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDITechChallenge.Application.Interfaces
{
    public interface ICardService
    {
        Task<TokenViewModel> PostCard(CardViewModel cardViewModel);
    }
}
