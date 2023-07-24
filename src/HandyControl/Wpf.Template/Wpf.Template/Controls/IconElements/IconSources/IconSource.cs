using System.Windows;
using System.Windows.Media;

namespace Wpf.Template.Controls;

public abstract class IconSource : DependencyObject
{
    public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
        nameof(Foreground),
        typeof(Brush),
        typeof(IconSource),
        new FrameworkPropertyMetadata(SystemColors.ControlTextBrush)
    );

    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    public abstract IconElement CreateIconElement();
}
