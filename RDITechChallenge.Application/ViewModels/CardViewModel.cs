using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RDITechChallenge.Application.ViewModels
{
    [DataContract]
    public class CardViewModel
    {
        [Required(ErrorMessage = "The CustomerId is required")]
        [DisplayName("CustomerId")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid value for CustomerId")]
        [DataMember]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "The CardNumber is required")]
        [DisplayName("CardNumber")]
        [Range(1, 9999999999999999, ErrorMessage = "Invalid value for CardNumber")]
        public long CardNumber { get; set; }

        [Required(ErrorMessage = "The CVV is required")]
        [DisplayName("CVV")]
        [Range(1, 99999, ErrorMessage = "Invalid value for CVV")]
        public int CVV { get; set; }
    }
}
