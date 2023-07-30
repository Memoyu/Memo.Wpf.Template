using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Template.Controls;
using Microsoft.Extensions.Logging;

namespace HandyControl.Template.ViewModels;

public class SettingViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;
    private readonly ILogger _logger;

    public SettingViewModel(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<SettingViewModel>();
    }

    private void InitializeData()
    {
        _isInitialized = true;
    }

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeData();
    }

    public void OnNavigatedFrom()
    {
        throw new System.NotImplementedException();
    }
}
