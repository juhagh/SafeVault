using NUnit.Framework;
using SafeVault.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuthentication
    {
        [Test]
        public void PasswordHashing_WorksCorrectly()
        {
            TestContext.WriteLine("Running PasswordHashing_WorksCorrectly");
            string password = "Test123!";
            string hash = AuthService.HashPassword(password);

            Assert.That(AuthService.VerifyPassword(password, hash), Is.True);
        }

        [Test]
        public void InvalidPassword_IsRejected()
        {
            TestContext.WriteLine("Running InvalidPassword_IsRejected");
            string hash = AuthService.HashPassword("CorrectPassword");

            Assert.That(AuthService.VerifyPassword("WrongPassword", hash), Is.False);
        }
    }
}