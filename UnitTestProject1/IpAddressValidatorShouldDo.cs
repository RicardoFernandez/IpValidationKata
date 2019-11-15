using System;
using IpValidationKata;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class IpAddressValidatorShouldDo
    {   
        [TestCase("1.1.1.0")]
        [TestCase("1.1.1.255")]
        [TestCase("a.a.a.a")]
        [TestCase("1.1.1.1.1")]
        [TestCase("256.0.0.1")]
        [TestCase("1,1.1.1.1")]
        [TestCase("....")]
        [TestCase("1. 1. 1. 1 ")]
        [TestCase("ø.1.1.2")]
        [Test]
        public void Validate_InvalidIp_ReturnFalse(string ipAddress)
        {
            IpAddressValidator validator = new IpAddressValidator();
            var isValidIp = validator.Validate(ipAddress);
            Assert.IsFalse(isValidIp);
        }

    }
}
