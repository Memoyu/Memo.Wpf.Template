using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using FontFamily = System.Windows.Media.FontFamily;
using FontStyle = System.Windows.FontStyle;
using SystemFonts = System.Windows.SystemFonts;

namespace HandyControl.Template.Controls;

public class FontIcon : IconElement
{
    #region Static properties

    public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(
        nameof(FontFamily),
        typeof(FontFamily),
        typeof(FontIcon),
        new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, OnFontFamilyChanged)
    );

    public static readonly DependencyProperty FontSizeProperty =
        TextElement.FontSizeProperty.AddOwner(
            typeof(FontIcon),
            new FrameworkPropertyMetadata(
                SystemFonts.MessageFontSize,
                FrameworkPropertyMetadataOptions.Inherits,
                OnFontSizeChanged
            )
        );

    public static readonly DependencyProperty FontStyleProperty = DependencyProperty.Register(
        nameof(FontStyle),
        typeof(FontStyle),
        typeof(FontIcon),
        new FrameworkPropertyMetadata(FontStyles.Normal, OnFontStyleChanged)
    );

    public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
        nameof(FontWeight),
        typeof(FontWeight),
        typeof(FontIcon),
        new FrameworkPropertyMetadata(FontWeights.Normal, OnFontWeightChanged)
    );

    public static readonly DependencyProperty GlyphProperty = DependencyProperty.Register(
        nameof(Glyph),
        typeof(string),
        typeof(FontIcon),
        new FrameworkPropertyMetadata(string.Empty, OnGlyphChanged)
    );

    #endregion

    #region Properties

    [Bindable(true), Category("Appearance")]
    [Localizability(LocalizationCategory.Font)]
    public FontFamily FontFamily
    {
        get => (FontFamily)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    [TypeConverter(typeof(FontSizeConverter))]
    [Bindable(true), Category("Appearance")]
    [Localizability(LocalizationCategory.None)]
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    [Bindable(true), Category("Appearance")]
    public FontStyle FontStyle
    {
        get => (FontStyle)GetValue(FontStyleProperty);
        set => SetValue(FontStyleProperty, value);
    }

    [Bindable(true), Category("Appearance")]
    public FontWeight FontWeight
    {
        get => (FontWeight)GetValue(FontWeightProperty);
        set => SetValue(FontWeightProperty, value);
    }

    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    #endregion

    protected TextBlock? TextBlock;

    protected override UIElement InitializeChildren()
    {
        if (VisualParent is not null)
        {
            FontSize = TextElement.GetFontSize(VisualParent);
        }

        if (FontSize.Equals(SystemFonts.MessageFontSize))
        {
            SetResourceReference(FontSizeProperty, "DefaultIconFontSize");
        }

        TextBlock = new TextBlock
        {
            Style = null,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Center,
            TextAlignment = TextAlignment.Center,
            FontFamily = FontFamily,
            FontSize = FontSize,
            FontStyle = FontStyle,
            FontWeight = FontWeight,
            Text = Glyph,
            Visibility = Visibility.Visible,
            Focusable = false,
        };

        Focusable = false;

        return TextBlock;
    }

    #region Static methods

    private static void OnFontFamilyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        var self = (FontIcon)d;
        if (self.TextBlock is null)
            return;

        self.TextBlock.FontFamily = (FontFamily)e.NewValue;
    }

    private static void OnFontSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = (FontIcon)d;
        if (self.TextBlock is null)
            return;

        self.TextBlock.FontSize = (double)e.NewValue;
    }

    private static void OnFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = (FontIcon)d;
        if (self.TextBlock is null)
            return;

        self.TextBlock.FontStyle = (FontStyle)e.NewValue;
    }

    private static void OnFontWeightChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e
    )
    {
        var self = (FontIcon)d;
        if (self.TextBlock is null)
            return;

        self.TextBlock.FontWeight = (FontWeight)e.NewValue;
    }

    private static void OnGlyphChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var self = (FontIcon)d;
        if (self.TextBlock is null)
            return;

        self.TextBlock.Text = (string)e.NewValue;
    }

    #endregion
}
