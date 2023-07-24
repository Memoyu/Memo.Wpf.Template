using System.Windows;

namespace Wpf.Template.Controls;

public class SymbolIconSource : IconSource
{
    public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
        nameof(FontSize),
        typeof(double),
        typeof(SymbolIconSource),
        new PropertyMetadata(SystemFonts.MessageFontSize)
    );

    public static readonly DependencyProperty FontStyleProperty = DependencyProperty.Register(
        nameof(FontStyle),
        typeof(FontStyle),
        typeof(SymbolIconSource),
        new PropertyMetadata(FontStyles.Normal)
    );

    public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
        nameof(FontWeight),
        typeof(FontWeight),
        typeof(SymbolIconSource),
        new PropertyMetadata(FontWeights.Normal)
    );

    public static readonly DependencyProperty SymbolProperty = DependencyProperty.Register(
        nameof(Symbol),
        typeof(SymbolRegular),
        typeof(SymbolIconSource),
        new PropertyMetadata(SymbolRegular.Empty)
    );

    public static readonly DependencyProperty FilledProperty = DependencyProperty.Register(
        nameof(Filled),
        typeof(bool),
        typeof(SymbolIconSource),
        new PropertyMetadata(false)
    );

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

    public SymbolRegular Symbol
    {
        get => (SymbolRegular)GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }

    public bool Filled
    {
        get => (bool)GetValue(FilledProperty);
        set => SetValue(FilledProperty, value);
    }

    public override IconElement CreateIconElement()
    {
        SymbolIcon symbolIcon = new(Symbol, FontSize, Filled);

        if (!FontSize.Equals(SystemFonts.MessageFontSize))
        {
            symbolIcon.FontSize = FontSize;
        }

        if (FontWeight != FontWeights.Normal)
        {
            symbolIcon.FontWeight = FontWeight;
        }

        if (FontStyle != FontStyles.Normal)
        {
            symbolIcon.FontStyle = FontStyle;
        }

        if (Foreground != SystemColors.ControlTextBrush)
        {
            symbolIcon.Foreground = Foreground;
        }

        return symbolIcon;
    }
}
