using CreditCardValidationBL.AbstractClasses;
using CreditCardValidationBL.Models;
using CreditCardValidationBL.Services.Types;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Services
{

    /// <summary>
    /// Card validation service.
    /// </summary>
    public class CreditCartValidationService : ICreditCartValidationService
    {
        private AmexCardValidationService _amexService;
        private DiscoverCardValidationService _discoverService;
        private MasterCardValidationService _masterService;
        private VisaCardValidationService _visaService;

        public CreditCartValidationService(AmexCardValidationService amexService, DiscoverCardValidationService discoverService, MasterCardValidationService masterService, VisaCardValidationService visaService)
        {
            _amexService = amexService;
            _discoverService = discoverService;
            _masterService = masterService;
            _visaService = visaService;
        }
        /// <summary>
        /// Main method to validate all inputs by the user. if any of the validations are failed, card will be considerd as an invalid card.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateCardNumber(CreditCardDetailModel details)
        {
            ValidationResult IsValidLength = new ValidationResult();

            switch (details.Type)
            {
                case (int)CreditCardType.AMEX:
                    IsValidLength = _amexService.ValidateCardNumber(details.CardNumber);
                    break;
                case (int)CreditCardType.Visa:
                    IsValidLength = _visaService.ValidateCardNumber(details.CardNumber);
                    break;
                case (int)CreditCardType.MasterCard:
                    IsValidLength = _masterService.ValidateCardNumber(details.CardNumber);
                    break;
                case (int)CreditCardType.Discover:
                    IsValidLength = _discoverService.ValidateCardNumber(details.CardNumber);
                    break;
                default:
                    IsValidLength = new ValidationResult();
                    break;
            }
            return IsValidLength;

        }
    }
}
