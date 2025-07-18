using Material.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp;

public interface ILoginViewModel
{
    // 用于导航菜单显示的标题或名称
    string Header { get; }

    MaterialIconKind IconKind { get; }
}
