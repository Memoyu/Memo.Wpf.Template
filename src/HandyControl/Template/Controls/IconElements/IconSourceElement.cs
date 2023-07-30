using System;
using System.Windows;
using System.Windows.Markup;

namespace HandyControl.Template.Controls;

/// <summary>
/// Represents an icon that uses an IconSource as its content.
/// </summary>
[ContentProperty(nameof(IconSource))]
public class IconSourceElement : IconElement
{
    /// <summary>
    /// Property for <see cref="IconSource"/>.
    /// </summary>
    public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(
        nameof(IconSource),
        typeof(IconSource),
        typeof(IconSourceElement),
        new FrameworkPropertyMetadata(null)
    );

    /// <summary>
    /// Gets or sets <see cref="IconSource"/>
    /// </summary>
    public IconSource? IconSource
    {
        get => (IconSource)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }

    protected override UIElement InitializeChildren()
    {
        //TODO come up with an elegant solution
        throw new InvalidOperationException($"Use {nameof(IconSourceElementConverter)} class.");
    }
}
