using HandyControl.Template.Controls;
using HandyControl.Template.ViewModels;

namespace HandyControl.Template.Views.Pages;

/// <summary>
/// DataGridPage.xaml 的交互逻辑
/// </summary>
public partial class DataGridPage : INavigableView<DataGridViewModel>
{
    public DataGridViewModel ViewModel { get; }

    public DataGridPage(DataGridViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
