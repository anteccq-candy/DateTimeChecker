using System;
using System.Diagnostics.CodeAnalysis;

namespace DateTimeChecker.Models;

public interface IDateTimeValidator
{
    bool Validate(string value, [NotNullWhen(true)] out string? formattedString, out DateTimeOffset result);
}