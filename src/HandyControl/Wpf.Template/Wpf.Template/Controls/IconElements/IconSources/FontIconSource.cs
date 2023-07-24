using System.Windows;
using System.Windows.Media;

namespace Wpf.Template.Controls;

public class FontIconSource : IconSource
{
    public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(
        nameof(FontFamily),
        typeof(FontFamily),
        typeof(FontIconSource),
        new PropertyMetadata(SystemFonts.MessageFontFamily)
    );

    public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
        nameof(FontSize),
        typeof(double),
        typeof(FontIconSource),
        new PropertyMetadata(SystemFonts.MessageFontSize)
    );

    public static readonly DependencyProperty FontStyleProperty = DependencyProperty.Register(
        nameof(FontStyle),
        typeof(FontStyle),
        typeof(FontIconSource),
        new PropertyMetadata(FontStyles.Normal)
    );

    public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
        nameof(FontWeight),
        typeof(FontWeight),
        typeof(FontIconSource),
        new PropertyMetadata(FontWeights.Normal)
    );

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(FontIconSource),
        new PropertyMetadata(string.Empty)
    );

    public FontFamily FontFamily
    {
        get => (FontFamily)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public FontWeight FontWeight
    {
        get => (FontWeight)GetValue(FontWeightProperty);
        set => SetValue(FontWeightProperty, value);
    }

    public FontStyle FontStyle
    {
        get => (FontStyle)GetValue(FontStyleProperty);
        set => SetValue(FontStyleProperty, value);
    }

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public override IconElement CreateIconElement()
    {
        FontIcon fontIcon = new FontIcon() { Glyph = Glyph };

        if (!Equals(FontFamily, SystemFonts.MessageFontFamily))
        {
            fontIcon.FontFamily = FontFamily;
        }

        if (!FontSize.Equals(SystemFonts.MessageFontSize))
        {
            fontIcon.FontSize = FontSize;
        }

        if (FontWeight != FontWeights.Normal)
        {
            fontIcon.FontWeight = FontWeight;
        }

        if (FontStyle != FontStyles.Normal)
        {
            fontIcon.FontStyle = FontStyle;
        }

        if (Foreground != SystemColors.ControlTextBrush)
        {
            fontIcon.Foreground = Foreground;
        }

        return fontIcon;
    }
}
