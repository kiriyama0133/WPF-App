using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons; // 确保 Material.Icons NuGet 包已安装
using myapp.Models; // 修正命名空间，通常模型类在 Models 文件夹下
using myapp.Models.Types;
using myapp.Services; // 引入 AuthService 和 INavigationService 的命名空间
using myapp.Services.RestSharpService;
using System;
using System.Threading.Tasks;
using System.Windows.Controls; // 用于 PasswordBox

namespace myapp.Pages.LoginPage;

public partial class LoginPageViewModel : ObservableObject, ILoginViewModel
{
    public string Name => "登录";
    public int Order => 0;
    public string Header => "用户登录";
    private readonly IDialogService _dialogService; // 注入 IDialogService

    public MaterialIconKind IconKind => MaterialIconKind.Login;

    [ObservableProperty] // MVVM Toolkit 会自动生成 Identifier 属性和 SetProperty 逻辑
    private string _identifier = string.Empty; // 初始化，避免 null 警告

    [ObservableProperty] // 用于UI加载状态，控制ProgressBar可见性或按钮启用禁用
    private bool _isLoggingIn;

    [ObservableProperty] // 用于显示错误信息给用户
    private string _errorMessage = string.Empty;

    // 注入的服务
    private readonly AuthService _authService;

    // 构造函数
    public LoginPageViewModel(AuthService authService, IDialogService dialogService)
    {
        _authService = authService;
        _dialogService = dialogService;
    }

    // [RelayCommand] 会自动生成 LoginCommand 属性
    // 并且因为方法签名有参数，会自动生成 AsyncRelayCommand<PasswordBox>
    // 也会自动查找 CanExecuteLogin 方法作为 CanExecute 逻辑
    [RelayCommand]
    public async Task ExecuteLoginAsync(PasswordBox passwordBox)
    {
        IsLoggingIn = true; // 开始登录，显示加载状态
        ErrorMessage = string.Empty; // 清空之前的错误信息
        try
        {
            string password = passwordBox.Password; // 从 PasswordBox 获取密码
            // 调用认证服务进行登录
            LoginResponse result = await _authService.LoginAsync(Identifier, password);
            // 登录成功后的逻辑
            Console.WriteLine($"登录成功! 消息: {result.message}, Token: {result.token}");
            await _dialogService.ShowMessageAsync(
            "来自 Login 页面",
            "登录成功！"
        );
        }
        catch (Exception ex)
        {
            // 捕获并显示错误消息

            ErrorMessage = $"登录失败: {ex.Message}"; // 将错误信息显示给用户
            await _dialogService.ShowMessageAsync(
            "来自 Login 页面",
            $"登录失败！{ex.Message}"
            );
            Console.Error.WriteLine($"登录失败捕获异常: {ex.Message}");
        }
        finally
        {
            IsLoggingIn = false; // 登录结束，关闭加载状态
            passwordBox.Clear(); // 无论成功失败，都清除密码字段以增加安全性
        }
    }
}