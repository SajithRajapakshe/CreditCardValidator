using CreditCardValidationBL.AbstractClasses;
using CreditCardValidationBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Services.Types
{
    public class MasterCardValidationService : CardType
    {
        public override ValidationResult ValidateNumberSequence(string cardNumber)
        {
            return base.ValidateNumberSequence(cardNumber);
        }

        public override ValidationResult ValidateNumberLength(string cardNumber)
        {
            return cardNumber.Length == 16 ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "Invalid number length" };
        }
        public override ValidationResult ValidateStartingPrefix(string cardNumber){

            var regex = new Regex(@"^(51|52|53|54|55)").ToString();

            return Regex.IsMatch(cardNumber, regex) ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "invalid starting number" };
        }

        public override ValidationResult ValidateCardNumber(string cardNumber)
        {
            return base.ValidateCardNumber(cardNumber);
        }

    }
}
