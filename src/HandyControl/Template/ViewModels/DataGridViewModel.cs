using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Template.Controls;
using HandyControl.Template.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HandyControl.Template.ViewModels;

public partial class DataGridViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;
    private readonly ILogger _logger;

    public DataGridViewModel(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<DataGridViewModel>();
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
