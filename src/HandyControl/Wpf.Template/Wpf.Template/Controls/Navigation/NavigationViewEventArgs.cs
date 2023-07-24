﻿// Based on Windows UI Library
// Copyright(c) Microsoft Corporation.All rights reserved.

// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows;

namespace Wpf.Template.Controls;

public class NavigatingCancelEventArgs : RoutedEventArgs
{
    public NavigatingCancelEventArgs(RoutedEvent routedEvent, object source)
        : base(routedEvent, source) { }

    public  object Page { get; init; }
    public bool Cancel { get; set; }
}

public class NavigatedEventArgs : RoutedEventArgs
{
    public NavigatedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
    { }

    public object Page { get; init; }
}
