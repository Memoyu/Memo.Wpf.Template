using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Wpf.Template.Controls;

[TypeConverter(typeof(IconElementConverter))]
public abstract class IconElement : FrameworkElement
{
    static IconElement()
    {
        FocusableProperty.OverrideMetadata(
            typeof(IconElement),
            new FrameworkPropertyMetadata(false)
        );
        KeyboardNavigation.IsTabStopProperty.OverrideMetadata(
            typeof(IconElement),
            new FrameworkPropertyMetadata(false)
        );
    }

    public static readonly DependencyProperty ForegroundProperty =
        TextElement.ForegroundProperty.AddOwner(
            typeof(IconElement),
            new FrameworkPropertyMetadata(
                SystemColors.ControlTextBrush,
                FrameworkPropertyMetadataOptions.Inherits,
                static (d, args) => ((IconElement)d).OnForegroundPropertyChanged(args)
            )
        );

    [Bindable(true), Category("Appearance")]
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    protected override int VisualChildrenCount => 1;

    private Grid? _layoutRoot;

    #region Protected methods

    protected abstract UIElement InitializeChildren();

    protected virtual void OnForegroundPropertyChanged(DependencyPropertyChangedEventArgs args) { }

    #endregion

    #region Layout methods

    private void EnsureLayoutRoot()
    {
        if (_layoutRoot != null)
            return;

        _layoutRoot = new Grid { Background = Brushes.Transparent, SnapsToDevicePixels = true, };

        _layoutRoot.Children.Add(InitializeChildren());
        AddVisualChild(_layoutRoot);
    }

    protected override Visual GetVisualChild(int index)
    {
        if (index != 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        EnsureLayoutRoot();
        return _layoutRoot!;
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        EnsureLayoutRoot();

        _layoutRoot!.Measure(availableSize);
        return _layoutRoot.DesiredSize;
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        EnsureLayoutRoot();

        _layoutRoot!.Arrange(new Rect(new Point(), finalSize));
        return finalSize;
    }

    #endregion
}
