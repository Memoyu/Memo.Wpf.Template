using HandyControl.Template.Controls;
using HandyControl.Template.ViewModels;

namespace HandyControl.Template.Views.Pages;

/// <summary>
/// DashboardPage.xaml 的交互逻辑
/// </summary>
public partial class DashboardPage : INavigableView<DashboardViewModel>
{
    public DashboardViewModel ViewModel { get; }

    public DashboardPage(DashboardViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
