namespace FactoryPasswordPolicyExample.Business.Policies.Factory
{
    public interface IPolicyFactory
    {
        IPolicy Create(Policy policy, PolicyArgs args);
    }
}
