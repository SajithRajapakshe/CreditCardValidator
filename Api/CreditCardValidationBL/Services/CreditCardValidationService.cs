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
    public class CreditCardValidationService
    {
        private readonly ICreditCardValidationService _genericValidationService;
        public CreditCardValidationService(ICreditCardValidationService genericValidationService)
        {
            _genericValidationService = genericValidationService;
        }
        public async Task<ValidationResult> ValidateCardNumber(string cardNumber)
        {
            return await _genericValidationService.ValidateCardNumber(cardNumber);
        }
    }
}
