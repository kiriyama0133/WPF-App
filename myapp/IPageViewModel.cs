using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace myapp;

public interface IPageViewModel
{
    // 用于导航菜单显示的标题或名称
    string Header { get; }

    // 对应页面的 View 实例。
    // ViewModel 不应该知道具体的 View 类型，但为了在 MainViewModel 中统一显示，
    // 我们在这里返回 UserControl 类型，它是所有 WPF 用户控件的基类。

    int Order {  get; }
    // 可以在这里添加其他通用属性或方法，例如：
    // Material.Icons.MaterialIconKind IconKind { get; } // 用于菜单图标
    // Task LoadDataAsync(); // 页面加载数据的方法

    MaterialIconKind IconKind { get; }
}
