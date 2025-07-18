using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// myapp/Models/ApiSettings.cs
namespace myapp.Models
{
    public class ApiSettings // 确保类名正确
    {
        public string BaseUrl { get; set; } = string.Empty; // 必须是公共的读写属性，并且添加默认值确保不会是 null
        public string LoggingLevel { get; set; } = string.Empty; // 确保所有属性都有公共的 getter/setter
    }
}