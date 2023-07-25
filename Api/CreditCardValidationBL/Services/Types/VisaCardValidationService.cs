using CreditCardValidationBL.AbstractClasses;
using CreditCardValidationBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Services.Types
{
    public class VisaCardValidationService : CardType, ICreditCardValidationService
    {
        public override ValidationResult ValidateNumberLength(string cardNumber)
        {
            return cardNumber.Length == 16 || cardNumber.Length == 13 ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "Invalid number length" };
        }

        public override ValidationResult ValidateStartingPrefix(string cardNumber)
        {
            return cardNumber.StartsWith('4') ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "invalid starting number" };
        }
    }
}
