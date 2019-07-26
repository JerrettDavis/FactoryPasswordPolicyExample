using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Passwords
{
    public interface IPasswordPolicyVerifier
    {
        IValidationResult Verify(string password);
    }
}