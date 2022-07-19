using System.Reactive.Linq;
using DateTimeChecker.Models;
using Reactive.Bindings;

namespace DateTimeChecker.ViewModels;

public class MainWindowViewModel
{
    public ReactivePropertySlim<string> InputDateTimeFormat { get; }
    public ReadOnlyReactivePropertySlim<bool> ValidationResult { get; }
    public ReadOnlyReactivePropertySlim<string> OutputDateTime { get; }

    public MainWindowViewModel(IDateTimeValidator validator)
    {

        InputDateTimeFormat = new ReactivePropertySlim<string>();
        var validatedStream = InputDateTimeFormat.Select(x =>
        {
            var result = validator.Validate(x, out var formattedString, out var date);
            return (isValid: result, formattedDateString: formattedString, date);
        });

        ValidationResult = new ReadOnlyReactivePropertySlim<bool>(validatedStream.Select(x => x.isValid));

        OutputDateTime = new ReadOnlyReactivePropertySlim<string>(validatedStream.Select(x
            => x.isValid
                ? $"🙆‍♀️ {x.formattedDateString} => {x.date}"
                : "🙅‍♀️ 変換できませんでした。"));
    }
}