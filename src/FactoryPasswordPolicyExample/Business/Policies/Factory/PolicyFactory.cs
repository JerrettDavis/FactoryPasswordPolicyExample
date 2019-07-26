using System;
using System.Collections.Generic;

namespace FactoryPasswordPolicyExample.Business.Policies.Factory
{
    public class PolicyFactory : IPolicyFactory
    {
        private readonly Dictionary<Policy, Func<PolicyArgs, IPolicy>> _policyDictionary = new Dictionary<Policy, Func<PolicyArgs, IPolicy>>
        {
            [Policy.LowerCase] = (args) => new LowerCasePolicy(args),
            [Policy.UpperCase] = (args) => new UpperCasePolicy(args),
            [Policy.MinimumLength] = (args) => new MinimumLengthPolicy(args),
            [Policy.MaximumLength] = (args) => new MaximumLengthPolicy(args),
            [Policy.NumericCharacters] = (args) => new NumbersPolicy(args),
            [Policy.SpecialCharacters] = (args) => new SpecialCharacterPolicy(args)
        };

        public IPolicy Create(Policy policy, PolicyArgs args)
        {
            return _policyDictionary[policy](args);
        }
    }
}
