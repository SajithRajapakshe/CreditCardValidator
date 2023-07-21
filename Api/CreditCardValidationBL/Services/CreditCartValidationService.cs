using CreditCardValidationBL.Models;
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
        /// <summary>
        /// Main method to validate all inputs by the user. if any of the validations are failed, card will be considerd as an invalid card.
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public async Task<ValidationResult> ValidateCardNumber(CreditCardDetailModel details)
        {
            details.CardNumber = Regex.Replace(details.CardNumber, @"\s+", "");
            ICollection<ValidationResult> validationResults = new List<ValidationResult>
            {
                //First validate the number length and prefix for each card type.
                ValidateNumberLength(details.CardNumber, details.Type),
                ValidateStartingPrefix(details.CardNumber, details.Type)
            };

            //IF ONLY the above validations are passed, execute the Luhn algorithm check.
            if (validationResults.Any(x => x.Type != ValidationResultType.INVALID))
                validationResults.Add(ValidateNumberSequence(details.CardNumber));

            return validationResults.Any(x => x.Type == ValidationResultType.INVALID) ?
                validationResults.FirstOrDefault(x => x.Type == ValidationResultType.INVALID) :
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "Valid card number" };

        }

        /// <summary>
        /// Validate card number length of each type
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public ValidationResult ValidateNumberLength(string cardNumber, int cardType)
        {
            bool IsValidLength = false;
           
            switch (cardType)
            {
                case (int)CreditCardType.AMEX:
                    IsValidLength = cardNumber.Length == 15 ? true : false;
                    break;
                case (int)CreditCardType.Visa:
                    IsValidLength = cardNumber.Length == 16 || cardNumber.Length == 13 ? true : false;
                    break;
                case (int)CreditCardType.MasterCard:
                    IsValidLength = cardNumber.Length == 16 ? true : false;
                    break;
                case (int)CreditCardType.Discover:
                    IsValidLength = cardNumber.Length == 16 ? true : false;
                    break;
                default:
                    IsValidLength = false;
                    break;
            }
            return IsValidLength ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "Invalid number size" };
        }

        /// <summary>
        /// Validating starting prefixes of card numbers- Each card type has different starting prefixes
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cardType"></param>
        /// <returns></returns>
        public ValidationResult ValidateStartingPrefix(string cardNumber, int cardType)
        {
            bool IsValidPrefix = false;
            
            switch (cardType)
            {
                case (int)CreditCardType.AMEX:
                    IsValidPrefix = cardNumber.StartsWith("34") || cardNumber.StartsWith("37") ? true : false;
                    break;
                case (int)CreditCardType.Visa:
                    IsValidPrefix = cardNumber.StartsWith('4') ? true : false;
                    break;
                case (int)CreditCardType.MasterCard:
                    var regex = new Regex(@"^(51|52|53|54|55)").ToString();
                    IsValidPrefix = Regex.IsMatch(cardNumber, regex);
                    break;
                case (int)CreditCardType.Discover:
                    IsValidPrefix = cardNumber.StartsWith("6011") ? true : false;
                    break;
                default:
                    IsValidPrefix = false;
                    break;
            }
            return IsValidPrefix ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "Invalid starting number" };
        }

        /// <summary>
        /// Validate the number using luhn algorithm
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public ValidationResult ValidateNumberSequence(string cardNumber)
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
    }
}
