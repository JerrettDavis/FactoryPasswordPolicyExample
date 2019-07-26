using System.Collections.Generic;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public class PolicyArgs
    {
        public string Title { get; set; }
        public string ErrorMessage { get; set; }

        // There's almost definitely a better way to handle this;
        public Dictionary<string, object> AdditionalParameters { get; set; } = new Dictionary<string, object>();

        public PolicyArgs()
        {
            AdditionalParameters = new Dictionary<string, object>();
        }

        public PolicyArgs(params KeyValuePair<string, object>[] parameters)
        {
            AdditionalParameters = new Dictionary<string, object>();
            foreach (var param in parameters)
            {
                AdditionalParameters.Add(param.Key, param.Value);
            }
        }
    }
}
