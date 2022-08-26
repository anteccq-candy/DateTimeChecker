using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using DateTimeChecker.Models;

namespace DateTimeChecker.Views.Converter;

internal class InputValidationToColorValidator : IValueConverter
{
    private static readonly SolidColorBrush ValidColor = new(Colors.Green);
    private static readonly SolidColorBrush EmptyColor = new(Colors.DimGray);
    private static readonly SolidColorBrush InvalidColor = new(Colors.DarkRed);

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not InputValidationResult validationResult)
            throw new NotImplementedException();

        return validationResult switch
        {
            InputValidationResult.Valid => ValidColor,
            InputValidationResult.Empty => EmptyColor,
            InputValidationResult.Error => InvalidColor,
            _ => throw new NotImplementedException()
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}