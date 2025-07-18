using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // 新增引用
using Microsoft.Extensions.Options;       // 新增引用，用于 Configure<T>
using myapp.Models;
using myapp.Pages.Dashboard;
using myapp.Pages.LoginPage;
using myapp.Pages.MessageDialog;
using myapp.Pages.Navicat;
using myapp.Services.RestSharpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.Services;

public static class ServiceConfiguration
{
    // 修正方法签名：现在接收 IConfiguration 参数
    public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. 注册 IConfiguration 实例到 DI 容器
        // 如果其他服务需要直接访问 IConfiguration，则需要注册
        services.AddSingleton(configuration);

        // 2. 注册配置对象 (IOptions<T>)将 appsettings.json 中的 "ApiSettings" 节绑定到 ApiSettings 类。
        services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));

        // 3. 定义 ViewModel 类型到 View (Page) 类型的映射
        var viewModelViewMap = new Dictionary<Type, Type>
        {
            { typeof(DashboardViewModel), typeof(DashboardView) },
            { typeof(NavicatViewModel), typeof(NavicatView) },
            { typeof(LoginPageViewModel), typeof(LoginPageView) }
            // TODO: 根据你的项目，添加所有其他 IPageViewModel 及其对应的 Page 映射
        };

        // 注册主窗口的View和ViewModel (通常是单例)
        services.AddSingleton<MainWindow>(); // <--- 确保这一行存在且正确
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<LoadingWindow>();

        // 其他页面的Views (建议 AddTransient，按需创建)
        services.AddTransient<DashboardView>();
        services.AddTransient<NavicatView>();
        services.AddTransient<MessageDialogView>();
        services.AddTransient<LoginPageView>();

        // 其他页面的ViewModels (建议 AddTransient，按需创建)
        services.AddTransient<IPageViewModel, DashboardViewModel>();
        services.AddTransient<IPageViewModel, NavicatViewModel>();
        services.AddTransient<ILoginViewModel, LoginPageViewModel>();

        // 其他通用服务
        services.AddSingleton(viewModelViewMap); // 注册映射字典
        services.AddSingleton<IViewResolver, ViewResolver>(); // 视图解析器
        services.AddScoped<dbContextService>(); // 数据库上下文服务，通常是 Scoped
        services.AddSingleton<IDialogService, DialogService>(); // 对话框服务
        services.AddSingleton<RestSharpServiceProvider>(); // RestSharp 服务提供者
        services.AddSingleton<AuthService>(); // 认证服务

        // 返回 services 集合，允许链式调用
        return services;
    }
}