using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myapp.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace myapp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider? serviceProvider { get;private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            // 确保 appsettings.json 被正确复制到输出目录
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // 设置配置文件的基本路径为应用程序的执行目录
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // 加载 appsettings.json
                .Build();

            base.OnStartup(e); // 基类方法
            var serviceCollection = new ServiceCollection();
            //配置服务
            serviceCollection.ConfigureAppServices(configuration);
            serviceProvider = serviceCollection.BuildServiceProvider(); // 从配置好的collection 构建 provider
            var mainWindow = serviceProvider.GetRequiredService<LoadingWindow>(); // 得到构建好的实例
            mainWindow.Show();
        }
    }
}
