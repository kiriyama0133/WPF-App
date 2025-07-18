using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace myapp.Pages.Dashboard;

class DashboardViewModel : ObservableObject, IPageViewModel
{
    public string Header => "主页";
    public int Order => 0;

    public MaterialIconKind IconKind => MaterialIconKind.Home; 

}