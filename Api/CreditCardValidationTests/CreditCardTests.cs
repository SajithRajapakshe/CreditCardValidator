using CreditCardValidationBL.Models;
using CreditCardValidationBL.Services;
using CreditCardValidationBL.Services.Types;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace CreditCardValidationTests
{
    /// <summary>
    /// Unit tests to run on card number length, prefix and luhn logic.
    /// </summary>
    public class CreditCardTests
    {
        private AmexCardValidationService _amexService;
        private DiscoverCardValidationService _discoverService;
        private MasterCardValidationService _masterService;
        private VisaCardValidationService _visaService;

        [SetUp]
        public void SetUp()
        {
            _amexService = new AmexCardValidationService();
            _discoverService = new DiscoverCardValidationService();
            _masterService = new MasterCardValidationService();
            _visaService = new VisaCardValidationService();
        }

        [Test]
        [TestCase("378282246310005")]
        public void AmexCard_Valid(string cardNumber)
        {
            Assert.That(_amexService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("3782822463100015")]
        public void AmexCard_Invalid(string cardNumber)
        {
            Assert.That(_amexService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.INVALID));
        }


        [Test]
        [TestCase("6011111111111117")]
        public void DiscoverCard_Valid(string cardNumber)
        {
            Assert.That(_discoverService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("6011111111111118")]
        public void DiscoverCard_Invalid(string cardNumber)
        {
            Assert.That(_discoverService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.INVALID));
        }

        [Test]
        [TestCase("5105105105105100")]
        public void MasterCard_Valid(string cardNumber)
        {
            Assert.That(_masterService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("5105105105105106")]
        public void MasterCard_Invalid(string cardNumber)
        {
            Assert.That(_masterService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.INVALID));
        }


        [Test]
        [TestCase("4111111111111111")]
        public void VisaCard_Valid(string cardNumber)
        {
            Assert.That(_visaService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.VALID));
        }

        [Test]
        [TestCase("4111111111111112")]
        public void VisaCard_Invalid(string cardNumber)
        {
            Assert.That(_visaService.ValidateCardNumber(cardNumber).Type, Is.EqualTo(ValidationResultType.INVALID));
        }

    }
}