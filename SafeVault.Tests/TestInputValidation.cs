using NUnit.Framework;
using SafeVault.Models;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        [Test]
        public void TestForSQLInjection()
        {
            TestContext.WriteLine("Running TestForSQLInjection");
            
            string maliciousInput = "' OR 1=1 --";
            string sanitized = UserInput.Sanitize(maliciousInput);
            
            Assert.That(sanitized.Contains("'"), Is.False);
            Assert.That(sanitized.Contains("--"), Is.False);
        }

        [Test]
        public void TestForXSS()
        {
            TestContext.WriteLine("Running TestForXSS");
            
            string maliciousScript = "<script>alert('xss')</script>";
            string sanitized = UserInput.Sanitize(maliciousScript);

            Assert.That(sanitized.Contains("<script>"), Is.False);
        }
    }
}