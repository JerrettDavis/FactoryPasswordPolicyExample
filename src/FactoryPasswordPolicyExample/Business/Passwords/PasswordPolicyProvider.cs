using FactoryPasswordPolicyExample.Business.Policies;
using FactoryPasswordPolicyExample.Business.Policies.Factory;
using System.Collections.Generic;

namespace FactoryPasswordPolicyExample.Business.Passwords
{
    public class PasswordPolicyProvider : IPasswordPolicyProvider
    {
        private readonly IPolicyFactory _policyFactory;

        public PasswordPolicyProvider(IPolicyFactory policyFactory)
        {
            _policyFactory = policyFactory;
        }

        public IPolicy[] GetPolicies()
        {
            return new []
            {
                _policyFactory.Create(Policy.LowerCase, new PolicyArgs(new KeyValuePair<string, object>("MinimumLength", 1))),
                _policyFactory.Create(Policy.UpperCase, new PolicyArgs(new KeyValuePair<string, object>("MinimumLength", 1))),
                _policyFactory.Create(Policy.NumericCharacters, new PolicyArgs(new KeyValuePair<string, object>("MinimumLength", 1))),
                _policyFactory.Create(Policy.SpecialCharacters, new PolicyArgs(new KeyValuePair<string, object>("MinimumLength", 1))),
                _policyFactory.Create(Policy.MinimumLength, new PolicyArgs(new KeyValuePair<string, object>("MinimumLength", 8)))
            };
        }
    }
}
