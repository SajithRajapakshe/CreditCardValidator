﻿using CreditCardValidationBL.AbstractClasses;
using CreditCardValidationBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Services.Types
{
    public class DiscoverCardValidationService : CardType
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

        public override ValidationResult ValidateStartingPrefix(string cardNumber)
        {
            return cardNumber.StartsWith("6011") ?
                new ValidationResult() { Type = ValidationResultType.VALID, ResultMessage = "" } :
                new ValidationResult() { Type = ValidationResultType.INVALID, ResultMessage = "starting number" };
        }

        public override ValidationResult ValidateCardNumber(string cardNumber)
        {
            return base.ValidateCardNumber(cardNumber);
        }
    }
}
