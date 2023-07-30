using System.Collections.Generic;

namespace HandyControl.Template.Models;

public class DataGridModel
{
    public int Index { get; set; }

    public string Name { get; set; }

    public bool IsSelected { get; set; }

    public string Remark { get; set; }

    public DataType Type { get; set; }

    public string ImgPath { get; set; }

    public List<DataGridModel> Childs { get; set; }
}

public enum DataType
{
    Type1 = 1,
    Type2,
    Type3,
    Type4,
    Type5,
    Type6
}