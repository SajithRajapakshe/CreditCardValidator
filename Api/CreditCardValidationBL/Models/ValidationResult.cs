using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Models
{
    /// <summary>
    /// A Class to add validation results and pass the correct result type to the UI.
    /// </summary>
    public class ValidationResult
    {
        public ValidationResultType Type { get; set; }

        public string? ResultMessage { get; set; }
    }
}
