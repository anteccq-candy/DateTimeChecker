using System;
using System.Reactive.Linq;
using DateTimeChecker.Models;
using Reactive.Bindings;

namespace DateTimeChecker.ViewModels;

public class MainWindowViewModel
{
    public ReactivePropertySlim<string> InputDateTimeFormat { get; }
    public ReadOnlyReactivePropertySlim<InputValidationResult> ValidationResult { get; }
    public ReadOnlyReactivePropertySlim<string> OutputDateTime { get; }

    public MainWindowViewModel(IDateTimeValidator validator)
    {

        InputDateTimeFormat = new ReactivePropertySlim<string>();
        var validatedStream = InputDateTimeFormat
            .Select(x =>
            {
                if (string.IsNullOrEmpty(x))
                    return new ValidateResult(InputValidationResult.Empty, null, null);

                var isValid = validator.Validate(x, out var formattedString, out var date);
                var result = isValid
                    ? InputValidationResult.Valid
                    : InputValidationResult.Error;
                return new ValidateResult(result, formattedString, date);
            });

        ValidationResult = new ReadOnlyReactivePropertySlim<InputValidationResult>(validatedStream.Select(x => x.ValidationResult));

        OutputDateTime = new ReadOnlyReactivePropertySlim<string>(validatedStream.Select(x
            => x.ValidationResult switch
            {
                InputValidationResult.Valid => $"🙆‍ {x.FormattedDateString} => {x.Date}",
                InputValidationResult.Error => "🙅‍ 変換できませんでした。",
                InputValidationResult.Empty => "",
                _ => ""
            }));
    }

    internal record ValidateResult(InputValidationResult ValidationResult, string? FormattedDateString, DateTimeOffset? Date);
}