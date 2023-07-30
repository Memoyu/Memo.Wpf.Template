using System;

namespace HandyControl.Template.Controls;

public interface INavigationWindow
{
    /// <summary>
    /// Lets you navigate to the selected page based on it's type. Should be used with <see cref="IPageService"/>.
    /// </summary>
    /// <param name="pageType"><see langword="Type"/> of the page.</param>
    bool Navigate(Type pageType);

    /// <summary>
    /// Lets you attach the service provider that delivers page instances to <see cref="INavigationView"/>.
    /// </summary>
    /// <param name="serviceProvider">Instance of the <see cref="IServiceProvider"/>.</param>
    void SetServiceProvider(IServiceProvider serviceProvider);

    /// <summary>
    /// Triggers the command to open a window.
    /// </summary>
    void ShowWindow();

    /// <summary>
    /// Triggers the command to close a window.
    /// </summary>
    void CloseWindow();
}
