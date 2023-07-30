using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Template.Controls;
using HandyControl.Template.Views.Pages;
using System.Collections.ObjectModel;

namespace HandyControl.Template.ViewModels;

public partial class DashboardViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;

    public DashboardViewModel()
    {

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
