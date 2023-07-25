using CreditCardValidationBL.Models;
using CreditCardValidationBL.Services;
using CreditCardValidationBL.Services.Types;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CreditCardValidationApi.Controllers
{
    [ApiController]
    public class CreditCardValidationController : ControllerBase
    {
        /// <summary>
        /// Validation method. Accepts the card details, validating and return the respnonse 
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreditCardValidator")]
        public async Task<ValidationResult> ValidateCardDetails([FromForm] CreditCardDetailModel details)
        {
            string cardNumber = details.CardNumber;
            var regex = new Regex(@"^(51|52|53|54|55)").ToString();

            if (cardNumber.Length == 15 && (cardNumber.StartsWith("34") || cardNumber.StartsWith("37")))
            {
                CreditCardValidationService service = new CreditCardValidationService(new AmexCardValidationService());
                return await service.ValidateCardNumber(cardNumber);
            }
            else if (cardNumber.Length == 16 && cardNumber.StartsWith("6011"))
            {
                CreditCardValidationService service = new CreditCardValidationService(new DiscoverCardValidationService());
                return await service.ValidateCardNumber(cardNumber);
            }
            else if ((cardNumber.Length == 16 || cardNumber.Length == 13) && cardNumber.StartsWith("4"))
            {
                CreditCardValidationService service = new CreditCardValidationService(new VisaCardValidationService());
                return await service.ValidateCardNumber(cardNumber);
            }
            else if (cardNumber.Length == 16 && Regex.IsMatch(cardNumber, regex))
            {
                CreditCardValidationService service = new CreditCardValidationService(new MasterCardValidationService());
                return await service.ValidateCardNumber(cardNumber);

            }
            else
            {
                return new ValidationResult() { ResultMessage = "Number length or starting prefix is invalid", Type = ValidationResultType.INVALID };
            }


        }
    }
}