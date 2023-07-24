using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Wpf.Template.Controls;

public sealed class IconSourceElementConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
        ConvertToIconElement(value);

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture
    ) => throw new NotImplementedException();

    public static object ConvertToIconElement(DependencyObject _, object baseValue) =>
        ConvertToIconElement(baseValue);

    private static object ConvertToIconElement(object value)
    {
        if (value is not IconSourceElement iconSourceElement)
            return value;

        if (iconSourceElement.IconSource is null)
            throw new ArgumentException(nameof(iconSourceElement.IconSource));

        return iconSourceElement.IconSource.CreateIconElement();
    }
}
