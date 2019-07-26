using System;
using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public class MinimumLengthPolicy : IPolicy
    {
        private const string _defaultTitle = "MinimumLength";
        private readonly int _minimumLength;
        private readonly string _errorMessage;
        private readonly string _errorTitle;

        public MinimumLengthPolicy(PolicyArgs args)
        {
            if (args == null)
                throw new ArgumentException();

            const string parameterName = "MinimumLength";
            if (!args.AdditionalParameters.ContainsKey(parameterName))
                throw new ArgumentException("Minimum Length is not provided.");

            if (!int.TryParse(args.AdditionalParameters[parameterName].ToString(), out var minimumLength))
                throw new ArgumentException("Minimum Length is invalid.");

            _minimumLength = minimumLength;
            _errorTitle = args.Title ?? _defaultTitle;
            _errorMessage = args.ErrorMessage ?? $"Input does not meet the minimum length requirement set by the password policy ({_minimumLength})";
        }

        public (bool, ErrorResponse) Verify(string input)
        {
            var longEnough = input.Length >= _minimumLength;
            return !longEnough ?
                (false, new ErrorResponse(_errorTitle, _errorMessage))
                : (true, null);
        }
    }
}
