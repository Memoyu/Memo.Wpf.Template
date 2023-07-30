using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Template.Controls;
using HandyControl.Template.Models;
using HandyControl.Template.Views.Pages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.ObjectModel;

namespace HandyControl.Template.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private bool _isInitialized = false;
    private readonly ILogger _logger;
    private AppSettings _appSettings;

    [ObservableProperty] string title;
    [ObservableProperty] ObservableCollection<object> navigationItems = new();
    [ObservableProperty] ObservableCollection<object> navigationFooter = new();


    public MainWindowViewModel(ILoggerFactory loggerFactory, IOptions<AppSettings> options)
    {
        _logger = loggerFactory.CreateLogger<MainWindowViewModel>();
        _appSettings = options.Value;
        if (!_isInitialized)
            InitializeData();
    }

    private void InitializeData()
    {
        NavigationItems = new ObservableCollection<object>
        {
            new NavigationViewItem()
            {
                Content = "主页",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "数据表格",
                Icon = new SymbolIcon { Symbol = SymbolRegular.DataArea24 },
                TargetPageType = typeof(DataGridPage),
                MenuItems = new NavigationViewItem[]
                {
                    new NavigationViewItem
                    {
                        Content = "子页面-1",
                        Icon = new SymbolIcon { Symbol = SymbolRegular.DataArea24 },
                        TargetPageType = typeof(DataGridChild1Page)
                    },
                     new NavigationViewItem
                    {
                        Content = "子页面-2",
                        Icon = new SymbolIcon { Symbol = SymbolRegular.DataArea24 },
                        TargetPageType = typeof(DataGridChild2Page)
                    }
                }

            }
         };

        NavigationFooter = new ObservableCollection<object>
        {
            new NavigationViewItem()
            {
                Content = "设置",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(SettingPage)
            }
        };

        Title = _appSettings.AppName;

        _isInitialized = true;
    }

}
