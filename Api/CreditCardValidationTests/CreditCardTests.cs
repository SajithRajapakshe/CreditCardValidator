using CreditCardValidationBL.Models;
using CreditCardValidationBL.Services;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace CreditCardValidationTests
{
    /// <summary>
    /// Unit tests to run on card number length, prefix and luhn logic.
    /// </summary>
    public class CreditCardTests
    {
        private CreditCartValidationService _service;
        [SetUp]
        public void SetUp()
        {
            _service = new CreditCartValidationService();
        }

        [Test]
        [TestCase("4111111111111111", 1)]
        [TestCase("378282246310005", 2)]
        [TestCase("5105105105105100", 3)]
        [TestCase("6011111111111117", 4)]
        public void IsValidCardNumberLength(string cardNumber, int cardType)
        {
            Assert.That(_service.ValidateNumberLength(cardNumber, cardType).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("411111111121111", 1)]
        [TestCase("37828224110005", 2)]
        [TestCase("51051051000", 3)]
        [TestCase("601111111117", 4)]
        public void IsInValidCardNumberLength(string cardNumber, int cardType)
        {
            Assert.That(_service.ValidateNumberLength(cardNumber, cardType).Type, Is.EqualTo(ValidationResultType.INVALID));
        }

        [Test]
        [TestCase("4012888888881881", 1)]
        [TestCase("378282246310005", 2)]
        [TestCase("5105105105105100", 3)]
        [TestCase("6011111111111117", 4)]
        public void IsValidCardNumberPrefix(string cardNumber, int cardType)
        {
            Assert.That(_service.ValidateStartingPrefix(cardNumber, cardType).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("5012888888881881", 1)]
        [TestCase("678282246310005", 2)]
        [TestCase("9105105105105100", 3)]
        [TestCase("8011111111111117", 4)]
        public void IsInValidCardNumberPrefix(string cardNumber, int cardType)
        {
            Assert.That(_service.ValidateStartingPrefix(cardNumber, cardType).Type, Is.EqualTo(ValidationResultType.INVALID));
        }


        [Test]
        [TestCase("4111111111111111")]
        [TestCase("4012888888881881")]
        [TestCase("378282246310005")]
        [TestCase("6011111111111117")]
        [TestCase("5105105105105100")]
        public void Luhn_IsValidCardNumber(string cardNumber)
        {
            Assert.That(_service.ValidateNumberSequence(cardNumber).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("4111111111111")]
        [TestCase("5105105105105106")]
        [TestCase("9105105105105100")]
        [TestCase("9111111111111111")]
        public void Luhn_IsInValidCardNumber(string cardNumber)
        {
            Assert.That(_service.ValidateNumberSequence(cardNumber).Type, Is.EqualTo(ValidationResultType.INVALID));
        }


    }
}