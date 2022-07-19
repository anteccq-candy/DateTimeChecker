using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DateTimeChecker.Views.Converter;

internal class BoolToColorValidator : IValueConverter
{
    private static readonly SolidColorBrush ValidColor = new(Colors.Green);
    private static readonly SolidColorBrush InvalidColor = new(Colors.DarkRed);

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? ValidColor : InvalidColor;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}