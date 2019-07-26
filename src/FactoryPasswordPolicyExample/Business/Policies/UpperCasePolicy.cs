using System;
using System.Text.RegularExpressions;
using FactoryPasswordPolicyExample.Models.Responses;

namespace FactoryPasswordPolicyExample.Business.Policies
{
    public class UpperCasePolicy : IPolicy
    {
        private const string _defaultTitle = "UpperCaseCount";
        private readonly int _minimumLength;
        private readonly string _errorMessage;
        private readonly string _errorTitle;

        public UpperCasePolicy(PolicyArgs args)
        {
            if (args == null)
                throw new ArgumentException();

            if (!args.AdditionalParameters.ContainsKey("MinimumLength"))
                throw new ArgumentException("Minimum Length is not provided.");

            if (!int.TryParse(args.AdditionalParameters["MinimumLength"].ToString(), out var minimumLength))
                throw new ArgumentException("Minimum Length is invalid.");

            _minimumLength = minimumLength;
            _errorTitle = args.Title ?? _defaultTitle;
            _errorMessage = args.ErrorMessage ?? $"Input does not meet the upper case character count requirement set by the password policy ({_minimumLength})";
        }

        public (bool, ErrorResponse) Verify(string input)
        {
            var enoughUpper = Regex.Matches(input, "[A-Z]").Count >= _minimumLength;
            return !enoughUpper ?
                (false, new ErrorResponse(_errorTitle, _errorMessage))
                : (true, null);
        }
    }
}
