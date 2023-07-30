using System;

namespace HandyControl.Template.Controls;

public static class SymbolGlyph
{
    public const SymbolRegular DefaultIcon = SymbolRegular.BorderNone24;

    public const SymbolFilled DefaultFilledIcon = SymbolFilled.BorderNone24;

    public static SymbolRegular Parse(string name)
    {
        if (string.IsNullOrEmpty(name))
            return DefaultIcon;

        try
        {
            return (SymbolRegular)Enum.Parse(typeof(SymbolRegular), name);
        }
        catch (Exception e)
        {
            return DefaultIcon;
        }
    }

    public static SymbolFilled ParseFilled(string name)
    {
        if (string.IsNullOrEmpty(name))
            return DefaultFilledIcon;

        try
        {
            return (SymbolFilled)Enum.Parse(typeof(SymbolFilled), name);
        }
        catch (Exception e)
        {
            return DefaultFilledIcon;
        }
    }
}
