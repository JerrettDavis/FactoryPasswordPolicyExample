using System.Collections.Generic;

namespace FactoryPasswordPolicyExample.Models.Responses
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        IEnumerable<ErrorResponse> Errors { get; }
    }
}
