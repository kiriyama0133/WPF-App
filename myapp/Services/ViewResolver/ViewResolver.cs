using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace myapp.Services
{
    public class ViewResolver : IViewResolver
    {
        private readonly IServiceProvider _serviceProvider;
        // 明确定义 ViewModel 类型到 View 类型的映射
        private readonly Dictionary<Type, Type> _viewModelViewMap;

        // 构造函数现在需要一个映射字典
        public ViewResolver(IServiceProvider serviceProvider, Dictionary<Type, Type> viewModelViewMap)
        {
            _serviceProvider = serviceProvider;
            _viewModelViewMap = viewModelViewMap ?? throw new ArgumentNullException(nameof(viewModelViewMap));
        }

        public Page ResolveViewForViewModel<TViewModel>(TViewModel viewModel) where TViewModel : class
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            Type viewModelType = typeof(TViewModel);

            // 1. 从映射中查找对应的 View 类型
            if (!_viewModelViewMap.TryGetValue(viewModelType, out Type? viewType))
            {
                throw new InvalidOperationException($"未在 ViewResolver 映射中找到 ViewModel 类型 '{viewModelType.Name}' 对应的 View (Page) 类型。");
            }

            // 2. 从 DI 容器中获取 View 实例
            if (!typeof(Page).IsAssignableFrom(viewType)) // 确保是 Page 类型
            {
                throw new InvalidOperationException($"映射的 View 类型 '{viewType.Name}' 不是一个 Page 或其派生类，无法作为 View。");
            }

            Page? view = _serviceProvider.GetService(viewType) as Page; // 直接通过 DI 获取 View 实例

            if (view == null)
            {
                throw new InvalidOperationException($"DI 容器无法解析 View (Page) 类型 '{viewType.Name}'。请确保已在 App.xaml.cs 中注册该类型。");
            }

            // 3. 设置 View 的 DataContext
            view.DataContext = viewModel;

            return view;
        }

        public Page ResolveView<TViewModel>() where TViewModel : class
        {
            Type viewModelType = typeof(TViewModel);

            if (!_viewModelViewMap.TryGetValue(viewModelType, out Type? viewType))
            {
                throw new InvalidOperationException($"未在 ViewResolver 映射中找到 ViewModel 类型 '{viewModelType.Name}' 对应的 View (Page) 类型。");
            }

            if (!typeof(Page).IsAssignableFrom(viewType))
            {
                throw new InvalidOperationException($"映射的 View 类型 '{viewType.Name}' 不是一个 Page 或其派生类。");
            }

            Page? view = _serviceProvider.GetService(viewType) as Page;
            if (view == null)
            {
                throw new InvalidOperationException($"DI 容器无法解析 View (Page) 类型 '{viewType.Name}'。请确保已在 App.xaml.cs 中注册该类型。");
            }
            return view;
        }
    }
}