using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public interface IPolicy
    {
        (bool, ErrorResponse) Verify(string input);
    }
}
