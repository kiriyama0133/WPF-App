using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace myapp.Services;

public interface IViewResolver
{
    Page ResolveViewForViewModel<TViewModel>(TViewModel viewModel) where TViewModel : class;
    Page ResolveView<TViewModel>() where TViewModel : class;
}
