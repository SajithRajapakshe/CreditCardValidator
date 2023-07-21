using CreditCardValidationBL.Models;
using CreditCardValidationBL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardValidationApi.Controllers
{
    [ApiController]
    public class CreditCardValidationController : ControllerBase
    {
        /// <summary>
        /// instances to inject dependencies.
        /// </summary>
        private readonly ILogger<CreditCardValidationController> _logger;
        private readonly ICreditCartValidationService _creditCardvalidationService;

        /// <summary>
        /// DI - Inject the dependencies to the constructor - Constructor injection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="creditCardvalidationService"></param>
        public CreditCardValidationController(ILogger<CreditCardValidationController> logger, ICreditCartValidationService creditCardvalidationService)
        {
            _logger = logger;
            _creditCardvalidationService = creditCardvalidationService;
        }


        /// <summary>
        /// Validation method. Accepts the card details, validating and return the respnonse 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreditCardValidator")]
        public async Task<ValidationResult> ValidateCardDetails([FromForm] CreditCardDetailModel details)
        {
            var result = await _creditCardvalidationService.ValidateCardNumber(details);
            return result;
        }
    }
}