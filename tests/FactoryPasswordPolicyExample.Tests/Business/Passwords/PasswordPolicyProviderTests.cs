using FactoryPasswordPolicyExample.Business.Passwords;
using FactoryPasswordPolicyExample.Business.Policies.Factory;
using System.Linq;
using Xunit;

namespace FactoryPasswordPolicyExample.Tests.Business.Passwords
{
    public class PasswordPolicyProviderTests
    {
        [Fact]
        public void GetPolicyTest_ShouldSucceed()
        {
            var factory = new PolicyFactory();
            var provider = new PasswordPolicyProvider(factory);
            var result = provider.GetPolicies();

            Assert.NotNull(result);
            Assert.True(result.Any());
        }
    }
}
