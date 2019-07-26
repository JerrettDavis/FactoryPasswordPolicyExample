using System;
using System.Text.RegularExpressions;
using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public class SpecialCharacterPolicy : IPolicy
    {
        private const string _defaultTitle = "SpecialCharacterCount";
        private readonly int _minimumLength;
        private readonly string _errorMessage;
        private readonly string _errorTitle;

        public SpecialCharacterPolicy(PolicyArgs args)
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
            _errorMessage = args.ErrorMessage ??  $"Input does not meet the special character count requirement set by the password policy ({_minimumLength})";
        }

        public (bool, ErrorResponse) Verify(string input)
        {
            var enoughUpper = Regex.Matches(input, @"[^0-9a-zA-Z\._]").Count >= _minimumLength;
            return !enoughUpper
                ? (false, new ErrorResponse(_errorTitle, _errorMessage))
                : (true, null);
        }
    }
}
