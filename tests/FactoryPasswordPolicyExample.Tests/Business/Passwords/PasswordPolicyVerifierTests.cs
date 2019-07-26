using FactoryPasswordPolicyExample.Business.Passwords;
using FactoryPasswordPolicyExample.Business.Policies.Factory;
using Xunit;

namespace FactoryPasswordPolicyExample.Tests.Business.Passwords
{
    public class PasswordPolicyVerifierTests
    {
        private readonly IPasswordPolicyVerifier _verifier;

        public PasswordPolicyVerifierTests()
        {
            var factory = new PolicyFactory();
            var provider = new PasswordPolicyProvider(factory);
            _verifier = new PasswordPolicyVerifier(provider);
        }
        [Fact]
        public void VerifyTest_ShouldSucceed()
        {
            var testPassword = "@Test12345";
            var result = _verifier.Verify(testPassword);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void VerifyTest_TooShort_ShouldFail()
        {
            var testPassword = "@Te1";
            var result = _verifier.Verify(testPassword);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void VerifyTest_NoUpper_ShouldFail()
        {
            var testPassword = "@test12345";
            var result = _verifier.Verify(testPassword);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void VerifyTest_NoLower_ShouldFail()
        {
            var testPassword = "@TEST12345";
            var result = _verifier.Verify(testPassword);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }

        [Fact]
        public void VerifyTest_NoSpecial_ShouldFail()
        {
            var testPassword = "Test12345";
            var result = _verifier.Verify(testPassword);

            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
        }
    }
}
