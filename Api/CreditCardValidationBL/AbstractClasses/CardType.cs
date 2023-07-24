using CreditCardValidationBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.AbstractClasses
{
    public abstract class CardType
    {
        public virtual ValidationResult ValidateNumberSequence(string cardNumber)
        {
            int i, checkSum = 0;


            // checksum of numbers starting from the last digit, back - 2.
            for (i = cardNumber.Length - 1; i >= 0; i -= 2)
                checkSum += (cardNumber[i] - '0');


            // Starting with the next to last digit and continuing with every other digit going back to the beginning of the card, double the digit and add to above checksum
            for (i = cardNumber.Length - 2; i >= 0; i -= 2)
            {
                int val = ((cardNumber[i] - '0') * 2);
                while (val > 0)
                {
                    checkSum += (val % 10);
                    val /= 10;
                }
            }

            // check that total is a multiple of 10, if so, the number is valid.
            var result = checkSum % 10 == 0;

            return result ?
               new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
               new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "Invalid card number" };
        }
        public abstract ValidationResult ValidateNumberLength(string cardNumber);
        public abstract ValidationResult ValidateStartingPrefix(string cardNumber);
        public virtual ValidationResult ValidateCardNumber(string cardNumber)
        {
            ICollection<ValidationResult> validationResults = new List<ValidationResult>
            {
                //First validate the number length and prefix for each card type.
                ValidateNumberLength(cardNumber),
                ValidateStartingPrefix(cardNumber)
            };
            //IF ONLY the above validations are passed, execute the Luhn algorithm check.
            if (validationResults.Any(x => x.Type != ValidationResultType.INVALID))
                validationResults.Add(ValidateNumberSequence(cardNumber));

            return validationResults.Any(x => x.Type == ValidationResultType.INVALID) ?
                validationResults.FirstOrDefault(x => x.Type == ValidationResultType.INVALID) :
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "Valid card number" };
        }
    }
}
