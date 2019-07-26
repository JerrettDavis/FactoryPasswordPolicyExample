using FactoryPasswordPolicyExample.Business.Policies;
using FactoryPasswordPolicyExample.Models.Passwords;
using FactoryPasswordPolicyExample.Models.Responses;
using FactoryPasswordPolicyExample.Models.Responses.Passwords;
using System.Collections.Generic;

namespace FactoryPasswordPolicyExample.Business.Passwords
{
    public class PasswordPolicyVerifier : IPasswordPolicyVerifier
    {
        private delegate (bool isValid, ErrorResponse error) VerificationMethod(string password);

        private readonly IPasswordPolicyProvider _policyProvider;

        public PasswordPolicyVerifier(IPasswordPolicyProvider policyProvider)
        {
            _policyProvider = policyProvider;
        }

        public IValidationResult Verify(string password)
        {
            var policies = _policyProvider.GetPolicies();
            return VerifyPassword(password, policies);
        }

        private static IValidationResult VerifyPassword(string password, IEnumerable<IPolicy> policies)
        {
            var isValid = true;
            var errors = new List<ErrorResponse>();

            foreach (var policy in policies)
            {
                var (isPasswordValid, error) = policy.Verify(password);
                if (!isPasswordValid)
                    isValid = false;
                if (error != null)
                    errors.Add(error);
            }

            return new PasswordValidationResult(isValid, errors);
        }
    }
}
