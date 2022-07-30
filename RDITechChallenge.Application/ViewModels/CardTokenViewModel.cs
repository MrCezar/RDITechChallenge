using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RDITechChallenge.Application.ViewModels
{
    public class CardTokenViewModel
    {
        [Required(ErrorMessage = "The CustomerId is required")]
        [DisplayName("CustomerId")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for CustomerId")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The CardId is required")]
        [DisplayName("CardId")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for CardId")]
        public int CardId { get; set; }

        [Required(ErrorMessage = "The Token is required")]
        [DisplayName("Token")]
        [Range(1, long.MaxValue, ErrorMessage = "Invalid value for Token")]
        public long Token { get; set; }

        [Required(ErrorMessage = "The CVV is required")]
        [DisplayName("CVV")]
        [Range(1, 99999, ErrorMessage = "Invalid value for CVV")]
        public int CVV { get; set; }
    }
}
