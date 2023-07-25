using CreditCardValidationBL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardValidationBL.Models
{
    /// <summary>
    /// Properties of credit card detail model
    /// </summary>
    public class CreditCardDetailModel
    {
        [Required]
        public string? CardNumber { get; set; }

        [Required]
        [CVVValidator]
        public int CVV { get; set; }

        [Required]
        [ExpiryDateValidator]
        public string? ExpireDate { get; set; }


    }
}
