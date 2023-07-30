using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Template.Controls;
using HandyControl.Template.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HandyControl.Template.ViewModels;

public partial class DataGridViewModel : ObservableObject, INavigationAware
{
    private bool _isInitialized = false;
    private readonly ILogger _logger;

    [ObservableProperty] IEnumerable<DataGridModel> datas = new DataGridModel[] { };

    public DataGridViewModel(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<DataGridViewModel>();
    }

    private void InitializeData()
    {
        var datas = new List<DataGridModel>();
        for (var i = 1; i <= 20; i++)
        {
            var childs = new List<DataGridModel>();
            for (var j = 0; j < 3; j++)
            {
                childs.Add(new DataGridModel
                {
                    Index = j,
                    IsSelected = j % 2 == 0,
                    Name = $"SubName{j}",
                    Type = (DataType)j
                });
            }
            var model = new DataGridModel
            {
                Index = i,
                IsSelected = i % 2 == 0,
                Name = $"Name{i}",
                Type = (DataType)(i % 6 + 1),
                Childs = childs,
                ImgPath = $"/HandyControl.Template;component/Resources/Avatar/avatar{i % 6 + 1}.png",
                Remark = new string(i.ToString()[0], 10)
            };
            datas.Add(model);
        }

        Datas = datas;

        _isInitialized = true;
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
