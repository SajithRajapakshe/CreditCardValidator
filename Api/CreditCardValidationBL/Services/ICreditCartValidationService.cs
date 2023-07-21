using CreditCardValidationBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Services
{
    /// <summary>
    /// Interface for card validation service
    /// </summary>
    public interface ICreditCartValidationService
    {
        Task<ValidationResult> ValidateCardNumber(CreditCardDetailModel details);
    }
}
