using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DateTimeChecker.Models;

public class DateTimeValidator : IDateTimeValidator
{
    public bool Validate(string value, [NotNullWhen(true)] out string? formattedString, out DateTimeOffset result)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            result = default;
            formattedString = null;
            return false;
        }

        var now = DateTimeOffset.Now;

        try
        {
            var formattedNowString = now.ToString(value, CultureInfo.InvariantCulture);
            if(DateTimeOffset.TryParse(formattedNowString, out result))
            {
                formattedString = formattedNowString;
                return true;
            }

            formattedString = null;
            return false;
        }
        catch
        {
            result = default;
            formattedString = null;
            return false;
        }
    }
}