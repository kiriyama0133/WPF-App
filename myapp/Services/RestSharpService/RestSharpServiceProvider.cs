using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Threading.Tasks;
using myapp.Models; // Ensure ApiSettings model is accessible

namespace myapp.Services.RestSharpService
{
    public class RestSharpServiceProvider
    {
        private readonly RestClient _client;

        public RestSharpServiceProvider(IOptions<ApiSettings> apiSettingsOptions)
        {
            string? baseUrl = apiSettingsOptions.Value.BaseUrl;

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException(
                    "BaseUrl configuration is missing or empty. " +
                    "Please ensure 'ApiSettings:BaseUrl' is defined in your appsettings.json."
                );
            }

            // --- THIS IS THE CORRECT WAY TO SET OPTIONS IN RESTSHARP 107+ ---
            // 1. Create a RestClientOptions object with the base URL.
            var options = new RestClientOptions(baseUrl)
            {
                // 2. Set the Timeout directly as a property of this options object.
                Timeout = TimeSpan.FromSeconds(30), // Set your desired timeout here (e.g., 30 seconds)
            };
            _client = new RestClient(options);
        }

        /// <summary>
        /// Executes an asynchronous request and deserializes the response to the specified type.
        /// </summary>
        public async Task<RestResponse<T>> ExecuteAsync<T>(RestRequest request)
        {
            return await _client.ExecuteAsync<T>(request);
        }

        /// <summary>
        /// Executes an asynchronous request without expecting a specific data type.
        /// </summary>
        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }
    }
}