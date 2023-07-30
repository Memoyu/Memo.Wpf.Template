using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Template.Controls;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HandyControl.Template.ViewModels;

public partial class DashboardViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;
    private readonly ILogger _logger;

    public DashboardViewModel(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<DashboardViewModel>();
    }

    private void InitializeData()
    {
        _isInitialized = true;
    }

    [RelayCommand]
    async Task WriteToLogClick()
    {
        _logger.LogDebug("写入Debug日志");
        _logger.LogInformation("写入Information日志");
        _logger.LogWarning("写入Warning日志");
        _logger.LogError("写入Error日志");

        await Task.CompletedTask;
    }

    public void OnNavigatedTo()
    {
        if (!_isInitialized)
            InitializeData();
    }

    public void OnNavigatedFrom()
    {
    }

}
