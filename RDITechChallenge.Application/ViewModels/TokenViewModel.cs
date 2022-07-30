using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RDITechChallenge.Application.ViewModels
{
    public class TokenViewModel
    {
        [Required(ErrorMessage = "The RegistrationDate is required")]
        [DisplayName("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "The Token is required")]
        [DisplayName("Token")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid value for Token")]
        public long Token { get; set; }

        [Required(ErrorMessage = "The CardId is required")]
        [DisplayName("CardId")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for CardId")]
        public int CardId { get; set; }
    }
}
