using System;
using System.Text;

namespace Wpf.Template.Controls;

public static class SymbolExtensions
{
    public static SymbolFilled Swap(this SymbolRegular icon)
    {
        return SymbolGlyph.ParseFilled(icon.ToString());
    }

    public static SymbolRegular Swap(this SymbolFilled icon)
    {
        return SymbolGlyph.Parse(icon.ToString());
    }

    public static string GetString(this SymbolRegular icon)
    {
        return Encoding.Unicode.GetString(BitConverter.GetBytes((int)icon)).TrimEnd('\0');
    }

    public static string GetString(this SymbolFilled icon)
    {
        return Encoding.Unicode.GetString(BitConverter.GetBytes((int)icon)).TrimEnd('\0');
    }
}
