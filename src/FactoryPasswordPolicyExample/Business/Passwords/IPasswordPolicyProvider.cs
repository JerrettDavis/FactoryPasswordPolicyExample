using FactoryPasswordPolicyExample.Business.Policies;

namespace FactoryPasswordPolicyExample.Business.Passwords
{
    public interface IPasswordPolicyProvider
    {
        IPolicy[] GetPolicies();
    }
}