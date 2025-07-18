using MaterialDesignThemes.Wpf;
using System;
using System.Threading.Tasks;
using myapp.Pages.MessageDialog; // 添加这个引用，指向您新的用户控件

namespace myapp.Services;

public class DialogService : IDialogService
{
    private const string DefaultDialogIdentifier = "RootDialog"; // 默认的DialogHost Identifier

    public async Task ShowMessageAsync(string title, string message)
    {
        // 实例化您的 MessageDialogView
        var messageDialogView = new MessageDialogView();

        // 将包含 Title 和 Message 的匿名对象设置为 MessageDialogView 的 DataContext
        messageDialogView.DataContext = new
        {
            Title = title,
            Message = message
        };

        // 直接将 UserControl 实例作为内容传递给 DialogHost.Show
        await DialogHost.Show(messageDialogView, DefaultDialogIdentifier);
    }

    public async Task<TResult?> ShowCustomDialogAsync<TResult>(object content, object? dialogIdentifier = null)
    {
        // 这个方法可以保持不变，因为它可能用于传递其他类型的 UIElement 或已经定义了 DataTemplate 的内容
        object identifier = dialogIdentifier ?? DefaultDialogIdentifier;
        return (TResult?)await DialogHost.Show(content, identifier);
    }
}