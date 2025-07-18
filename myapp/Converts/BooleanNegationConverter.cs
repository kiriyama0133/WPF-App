using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace myapp.Converts;

public class BooleanNegationConverter : IValueConverter
{
    // 当数据从源 (ViewModel) 传输到目标 (UI) 时调用
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return !boolValue; // 对布尔值取反
        }
        // 如果值不是布尔类型，或者为 null，则返回默认值或抛出异常
        // 这里我们返回 false，你可以根据实际需求调整
        return false;
    }

    // 当数据从目标 (UI) 传输回源 (ViewModel) 时调用（通常用于 TwoWay 绑定）
    // 在这种取反转换器中，如果需要 TwoWay 绑定，这个方法也需要实现取反
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return !boolValue; // 同样对布尔值取反
        }
        return false;
    }
}
