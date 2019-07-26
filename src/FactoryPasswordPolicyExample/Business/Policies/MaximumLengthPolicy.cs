using System;
using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public class MaximumLengthPolicy : IPolicy
    {
        private const string _defaultTitle = "MinimumLength";
        private readonly int _maximumLength;
        private readonly string _errorMessage;
        private readonly string _errorTitle;

        public MaximumLengthPolicy(PolicyArgs args)
        {
            if (args == null)
                throw new ArgumentException();

            const string parameterName = "MaximumLength";
            if (!args.AdditionalParameters.ContainsKey(parameterName))
                throw new ArgumentException("Maximum Length is not provided.");

            if (!int.TryParse(args.AdditionalParameters[parameterName].ToString(), out var minimumLength))
                throw new ArgumentException("Maximum Length is invalid.");

            _maximumLength = minimumLength;
            _errorTitle = args.Title ?? _defaultTitle;
            _errorMessage = args.ErrorMessage ?? $"Input does not meet the maximum length requirement set by the password policy ({_maximumLength})";
        }

        public (bool, ErrorResponse) Verify(string input)
        {
            var longEnough = input.Length >= _maximumLength;
            return !longEnough ?
                (false, new ErrorResponse(_errorTitle, _errorMessage))
                : (true, null);
        }
    }
}
