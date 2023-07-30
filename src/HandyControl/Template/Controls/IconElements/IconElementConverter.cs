using System;
using System.ComponentModel;
using System.Globalization;

namespace HandyControl.Template.Controls;

public class IconElementConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        if (sourceType == typeof(SymbolRegular))
            return true;

        if (sourceType == typeof(SymbolFilled))
            return true;

        return false;
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
        false;

    public override object? ConvertFrom(
        ITypeDescriptorContext? context,
        CultureInfo? culture,
        object? value
    ) =>
        value switch
        {
            SymbolRegular symbolRegular => new SymbolIcon(symbolRegular),
            SymbolFilled symbolFilled => new SymbolIcon(symbolFilled.Swap(), filled: true),
            _ => null
        };

    public override object ConvertTo(
        ITypeDescriptorContext? context,
        CultureInfo? culture,
        object? value,
        Type destinationType
    )
    {
        throw GetConvertFromException(value);
    }
}
