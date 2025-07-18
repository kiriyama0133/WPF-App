using myapp.Models.Types;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp.Services.RestSharpService;

public class AuthService
{
    private readonly RestSharpServiceProvider _restSharpProvider;
    public AuthService(RestSharpServiceProvider restSharpProvider)
    {
        _restSharpProvider = restSharpProvider;
    }

    /// <summary>
    /// 异步处理用户登录请求。
    /// </summary>
    /// <param name="identifier">用户的标识符，可以是用户名或邮箱。</param>
    /// <param name="password">用户的密码。</param>
    /// <returns>一个包含登录结果的 LoginResponse 对象（如果登录成功）。</returns>
    /// <exception cref="Exception">如果登录失败（无论是后端返回错误还是网络问题），则抛出异常，异常消息包含详细信息。</exception>
    public async Task<LoginResponse> LoginAsync(string identifier, string password)
    {
        // 1. 构建 RestRequest 对象
        //   - "auth/login" 是后端 API 的相对路径，会与 RestSharpServiceProvider 中的 BaseUrl 拼接成完整 URL。
        //   - Method.Post 指定这是一个 POST 请求。
        var request = new RestRequest("auth/login", Method.Post);

        // json req.body
        request.AddJsonBody(new LoginRequest { identifier = identifier, password = password });

        // commit asnyc req
        var response = await _restSharpProvider.ExecuteAsync<LoginResponse>(request);

        // 4. 处理响应结果
        // response.IsSuccessful 检查 HTTP 状态码是否在 2xx 范围内（例如 200 OK）。
        if (response.IsSuccessful)
        {
            // 如果 HTTP 请求成功，我们检查 Data 属性是否包含反序列化后的数据。
            // 在登录成功的场景下，response.Data 应该不为 null。
            if (response.Data != null)
            {
                // 登录成功，返回解析后的 LoginResponse 对象
                return response.Data;
            }
            else
            {
                // 如果 IsSuccessful 为 true，Data 不应为 null。
                throw new Exception("登录请求成功，但响应中未返回任何数据。");
            }
        }
        else // HTTP 状态码不是 2xx (例如 401 Unauthorized, 500 Internal Server Error)
        {
            // 登录失败的情况
            string errorMessage;

            // 尝试从后端返回的自定义错误消息中获取（如果后端在错误响应中也使用了 LoginResponse 结构）
            if (response.Data != null && !string.IsNullOrEmpty(response.Data.message))
            {
                errorMessage = response.Data.message;
            }
            // 如果没有后端自定义消息，尝试获取 RestSharp 内部的错误消息（例如网络连接问题）
            else if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                errorMessage = response.ErrorMessage;
            }
            // 如果以上都没有，尝试获取原始的响应内容
            else if (!string.IsNullOrEmpty(response.Content))
            {
                errorMessage = response.Content;
            }
            else
            {
                // 最后的兜底，如果无法获取具体错误信息
                errorMessage = $"未知登录错误 (HTTP 状态码: {response.StatusCode})。";
            }

            // 将详细错误信息输出到控制台，便于调试
            Console.Error.WriteLine($"登录失败，状态码 {response.StatusCode}。错误: {errorMessage}。内容: {response.Content}。异常: {response.ErrorException}");

            // 向上层（ViewModel）抛出包含有意义错误信息的异常
            throw new Exception($"登录失败: {errorMessage}");
        }
    }
}
