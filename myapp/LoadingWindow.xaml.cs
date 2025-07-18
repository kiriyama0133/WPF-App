using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace myapp
{
    /// <summary>
    /// LoadingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingWindow : Window
    {
        private readonly IServiceProvider serviceProvider;
        DispatcherTimer dispatchertimer = new DispatcherTimer();
        public LoadingWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            dispatchertimer.Tick += new EventHandler(OpenMainWindow);
            dispatchertimer.Interval = new TimeSpan(0, 0, 5);
            dispatchertimer.Start();
            this.serviceProvider = serviceProvider;
        }

        private void OpenMainWindow(object? sender, EventArgs e)
        {
            MainWindow main = serviceProvider.GetRequiredService<MainWindow>();
            main.Show();

            dispatchertimer.Stop();
            this.Close();
        }
    }
}
