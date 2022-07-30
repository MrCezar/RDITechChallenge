using Microsoft.AspNetCore.Mvc;
using RDITechChallenge.Application.Interfaces;
using RDITechChallenge.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace RDITechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardService _cardService;

        public CardController(ICardService cardService, ILogger<CardController> logger)
        {
            _cardService = cardService;
            _logger = logger;
        }

        /// <summary>
        /// Post customer card
        /// </summary>
        /// <param name="cardViewModel"></param>
        /// <returns>A newly created Token</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "customerId": 1,
        ///         "cardNumber": 1234567891234567,
        ///         "cvv": 12345
        ///     }
        /// </remarks>
        [HttpPost]
        [SwaggerOperation(OperationId = "PostCustomerCard", Summary = "Post customer card")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PostCustomerCard([FromBody] CardViewModel cardViewModel)
        {
            if (cardViewModel == null)
                return BadRequest("Card is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _cardService.PostCard(cardViewModel);

            return Ok(response);
        }
    }
}