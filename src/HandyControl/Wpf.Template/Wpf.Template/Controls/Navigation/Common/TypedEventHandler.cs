﻿namespace Wpf.Template.Controls.Navigation.Common;

public delegate void TypedEventHandler<in TSender, in TArgs>(TSender sender, TArgs args)
    where TSender : DependencyObject
    where TArgs : RoutedEventArgs;


public static class DesignerHelper
{
    private static bool _validated = false;

    private static bool _isInDesignMode = false;

    /// <summary>
    /// Indicates whether the project is currently in design mode.
    /// </summary>
    public static bool IsInDesignMode
    {
        get
        {
            if (_validated)
                return _isInDesignMode;

            _isInDesignMode = (bool)(
                DesignerProperties.IsInDesignModeProperty
                    .GetMetadata(typeof(DependencyObject))
                    ?.DefaultValue ?? false
            );
            _validated = true;

            return _isInDesignMode;
        }
    }

    /// <summary>
    /// Indicates whether the project is currently debugged.
    /// </summary>
    public static bool IsDebugging => System.Diagnostics.Debugger.IsAttached;
}


public static class ControlsServices
{
    internal static IServiceProvider? ControlsServiceProvider { get; private set; }

    /// <summary>
    /// Accepts a ServiceProvider for configuring dependency injection.
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void Initialize(IServiceProvider? serviceProvider)
    {
        if (serviceProvider == null)
            throw new ArgumentNullException(nameof(serviceProvider));

        ControlsServiceProvider = serviceProvider;
    }
}
