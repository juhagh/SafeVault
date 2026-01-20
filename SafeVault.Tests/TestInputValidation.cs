using NUnit.Framework;
using SafeVault.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SafeVault.Tests
{
    public class TestInputValidation
    {
        [Test]
        public void Username_ShouldReject_SQLInjection()
        {
            var input = new UserInput
            {
                Username = "admin' OR '1'='1",
                Email = "test@test.com"
            };

            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(input, new ValidationContext(input), results, true);

            Assert.That(isValid, Is.False);
        }

        [Test]
        public void Username_ShouldReject_XSS()
        {
            var input = new UserInput
            {
                Username = "<script>alert(1)</script>",
                Email = "test@test.com"
            };

            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(input, new ValidationContext(input), results, true);

            Assert.That(isValid, Is.False);
        }
    }
}