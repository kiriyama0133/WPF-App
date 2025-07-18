using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.Services;

public interface IDialogService
{
    // 确保这个方法签名存在于你的 IDialogService 接口中
    Task ShowMessageAsync(string title, string message);

    // 如果你之前还定义了 ShowCustomDialogAsync，也确保它还在
    Task<TResult?> ShowCustomDialogAsync<TResult>(object content, object? dialogIdentifier = null);
}
