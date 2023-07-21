using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Attributes
{
    /// <summary>
    /// Common validator for CVV - All card types
    /// </summary>
    public class CVVValidator : ValidationAttribute
    {
        /// <summary>
        /// Validation attribute to check whether the length of cvv is 3 or not.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            return value != null && Convert.ToString(value).Length == 3;
        }
    }
}
