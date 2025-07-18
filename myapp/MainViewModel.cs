
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input; 
using myapp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input; 

namespace myapp;

public class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IViewResolver _viewResolver;

    // _selectedPageViewModel 存储当前激活的逻辑 ViewModel
    private IPageViewModel? _selectedPageViewModel;
    private ILoginViewModel? _selectedLoginViewModel;
    public ObservableCollection<IPageViewModel> PageViewModels { get; }
    public ObservableCollection<ILoginViewModel> LoginViewModels { get; }

    // _currentPageContent 存储当前实际显示的 Page 实例，XAML 将绑定到此
    private Page? _currentPageContent;
    public Page? CurrentPageContent
    {
        get => _currentPageContent;
        // 使用 SetProperty 方法来确保 UI 收到属性变更通知
        set => SetProperty(ref _currentPageContent, value);
    }

    #region 更新页面ViewModel的页面
    public ILoginViewModel? SelectedLoginViewModel
    {
        get => _selectedLoginViewModel;
        set
        {
            if(SetProperty(ref _selectedLoginViewModel, value))
            {
                LoadCurrentPageContent("Login");
            }
        }
    }
    public IPageViewModel? SelectedPageViewModel
    {
        get => _selectedPageViewModel;
        // 使用 SetProperty 方法，并在这里触发 View 的解析和更新
        set
        {
            if (SetProperty(ref _selectedPageViewModel, value))
            {
                LoadCurrentPageContent("Menu");
            }
        }
    }
    #endregion

    // 抽屉开关状态管理
    public IRelayCommand ToggleDrawerCommand { get; }
    public IRelayCommand NavigateToLoginView { get; }
    private bool _isLeftDrawerOpen = true; // 默认打开
    private Visibility _isTextBlock = Visibility.Visible;
    public bool IsLeftDrawerOpen
    {
        get => _isLeftDrawerOpen;
        set => SetProperty(ref _isLeftDrawerOpen, value);
    }
    public Visibility IsTextBlock
    {
        set => SetProperty(ref _isTextBlock, value);
        get => _isTextBlock;
    }

    // 构造函数
    public MainViewModel(IEnumerable<IPageViewModel> pageViewModels, IServiceProvider serviceProvider, IViewResolver viewResolver,ILoginViewModel loginViewModel)
    {
        PageViewModels = new ObservableCollection<IPageViewModel>(
            pageViewModels.OrderBy(p => p.Order)
        );
        LoginViewModels = new ObservableCollection<ILoginViewModel> { loginViewModel }; // 登录页面
        _serviceProvider = serviceProvider;
        _viewResolver = viewResolver;
        ToggleDrawerCommand = new RelayCommand(() =>
        {
            //IsLeftDrawerOpen = !IsLeftDrawerOpen;
            if(IsTextBlock == Visibility.Visible)
            {
                IsTextBlock = Visibility.Collapsed;
            }
            else
            {
                IsTextBlock = Visibility.Visible;
            }
        });

        NavigateToLoginView = new RelayCommand(() =>
        {
            SelectedLoginViewModel = null; 
            SelectedLoginViewModel = LoginViewModels.FirstOrDefault();
        });

        SelectedPageViewModel = PageViewModels.FirstOrDefault();
    }

    /// <summary>
    /// 重新加载页面的函数,通过传入的string判断跳转到哪个页面
    /// </summary>
    /// <param name="PageType"></param>
    private void LoadCurrentPageContent(string PageType)
    {
        // Determine which ViewModel to load based on PageType
        object? viewModelToLoad = null;

        if (PageType == "Menu")
        {
            viewModelToLoad = _selectedPageViewModel;
        }
        else if (PageType == "Login")
        {
            viewModelToLoad = _selectedLoginViewModel;
        }
        // else if you have other page types, add more conditions here

        // Only proceed if a ViewModel is available
        if (viewModelToLoad != null)
        {
            try
            {
                Type actualViewModelType = viewModelToLoad.GetType(); // Now this is safe due to null check
                var resolveMethod = _viewResolver.GetType()
                    .GetMethod(nameof(IViewResolver.ResolveViewForViewModel))
                    ?.MakeGenericMethod(actualViewModelType); // Pass the actual runtime type as a generic parameter

                if (resolveMethod != null)
                {
                    // **IMPORTANT: Pass viewModelToLoad to Invoke, not _selectedPageViewModel**
                    var page = resolveMethod.Invoke(_viewResolver, new object[] { viewModelToLoad }) as Page;
                    CurrentPageContent = page;
                }
                else
                {
                    throw new InvalidOperationException($"ViewResolver's ResolveViewForViewModel method not found or does not conform to the expected signature for ViewModel type '{actualViewModelType.Name}'.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Failed to load page (ViewModel: {viewModelToLoad.GetType().Name}): {ex.Message}");
                // On failure, clear the current content
                CurrentPageContent = null;
            }
        }
        else
        {
            // If no ViewModel is selected or found for the PageType, clear content
            CurrentPageContent = null;
            // Optionally log a warning if a PageType was provided but no ViewModel was found
            if (!string.IsNullOrEmpty(PageType))
            {
                Console.WriteLine($"Warning: No ViewModel found for PageType '{PageType}'. CurrentPageContent set to null.");
            }
        }
    }
}