using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;
using Microsoft.EntityFrameworkCore;
using myapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using myapp.Services;
using System.Windows.Input;

namespace myapp.Pages.Navicat;

class NavicatViewModel : ObservableObject,IPageViewModel
{
    public string Header => "数据库浏览";
    public int Order => 1;
    public MaterialIconKind IconKind => MaterialIconKind.Navigation;
    private readonly dbContextService _dbContext; // 私有只读字段，用于存储注入的 DbContext
    // 用于 "测试Host" 按钮的命令
    public IRelayCommand ShowTestDialogCommand { get; }
    // 注入IDialogService 
    private readonly IDialogService _dialogService; // 注入 IDialogService
    public IRelayCommand SaveChangesCommand { get; } // 用于保存所有DataGrid上修改的命令
    private ObservableCollection<User>? _users;
    public ObservableCollection<User>? Users
    {
        get => _users;
        set => SetProperty(ref _users, value); // SetProperty 自动处理属性更改通知
    }
    private async Task loadUsersAsync()
    {
        try
        {
            if(_dbContext == null)
            { return; }
            var userList = await _dbContext.Users.ToListAsync();
            // 若是不包含数据
            if(userList != null && userList.Any())
            { if(Users != null) { Users.Clear();
                    foreach (var user in userList)
                    {
                        Users.Add(user);} } }
            else
            { Console.WriteLine("数据库里没有用户数据"); }
        }catch(Exception ex) {
            Console.WriteLine( $"加载用户失败: {ex}"); }}

    //构造函数
    public NavicatViewModel(dbContextService dbcontext, IDialogService dialogService)
    {
        _dbContext = dbcontext;
        Users = new ObservableCollection<User>(); // 初始化集合
        _ = loadUsersAsync();
        _dialogService = dialogService;
        ShowTestDialogCommand = new AsyncRelayCommand(ExecuteShowTestDialog);
        SaveChangesCommand = new AsyncRelayCommand(ExecuteSaveChanges);
    }

    // ==========================================================
    // "测试Host" 按钮的执行逻辑，通过 DialogService 调用
    // ==========================================================
    private async Task ExecuteShowTestDialog()
    {
        // 通过注入的 _dialogService 显示对话框
            await _dialogService.ShowMessageAsync(
            "来自 Navicat 页面的测试",
            "这是从 Navicat 页面按钮触发的对话框，通过 DialogService 调用！"
        );
    }

    // 新增：保存 DataGrid 中所有更改的命令
    private async Task ExecuteSaveChanges()
    {
        try
        {
            // EF Core 会自动检测 _dbContext 中所有追踪的实体（包括 Users 集合中的）的更改。
            // 当用户在 DataGrid 中编辑某个单元格并失去焦点后，DataGrid 会更新绑定到 ViewModel 的 User 对象。
            // 因为这些 User 对象是从 _dbContext.Users.ToListAsync() 加载出来的，它们已经被 DbContext 追踪。
            // 所以，_dbContext.SaveChangesAsync() 会自动识别这些被修改的实体，并生成 UPDATE 语句。
            int changesCount = await _dbContext.SaveChangesAsync();
            if (changesCount > 0)
            {
                await _dialogService.ShowMessageAsync("保存成功", $"已成功保存 {changesCount} 项更改到数据库。");
            }
            else
            {
                await _dialogService.ShowMessageAsync("提示", "没有检测到任何更改，无需保存。");
            }
        }
        catch (DbUpdateConcurrencyException ex)
        {
            // 处理并发冲突：当其他用户或进程同时修改了相同的数据时发生
            await _dialogService.ShowMessageAsync("并发冲突", $"数据已被其他用户修改，请刷新后重试。详情: {ex.Message}");
        }
        catch (Exception ex)
        {
            await _dialogService.ShowMessageAsync("错误", $"保存更改失败: {ex.Message}");
        }
    }
}
