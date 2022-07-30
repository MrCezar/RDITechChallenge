using Microsoft.AspNetCore.Mvc;
using RDITechChallenge.Application.Interfaces;
using RDITechChallenge.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace RDITechChallenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly ITokenService _tokenService;

        public TokenController(
            ITokenService tokenService,
            ILogger<TokenController> logger
            )
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Validate the provided token
        /// </summary>
        /// <param name="cardTokenViewModel"></param>
        /// <returns>Returns if the tokens is valid</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///         "customerId": 1,
        ///         "cardId": 1,
        ///         "token": 7456,
        ///         "CVV": 123454
        ///     }
        /// </remarks>
        [HttpPost]
        [SwaggerOperation(OperationId = "ValidateToken", Summary = "Validate the provided token")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ValidateToken(CardTokenViewModel cardTokenViewModel)
        {
            if (cardTokenViewModel == null)
                return BadRequest("CardToken is null");

            var isValid = await _tokenService.ValidateToken(cardTokenViewModel);

            return Ok(new
            {
                Validated = isValid
            });
        }
    }
}
