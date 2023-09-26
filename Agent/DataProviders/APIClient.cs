using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agent.DataProviders
{
    public class APIClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public APIClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }

        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string> queryParams = null)
        {
            T responseObject = default(T);

            try
            {
                // Construct the full URL including optional query parameters
                string url = $"{_baseUrl}/{endpoint}";

                if (queryParams != null && queryParams.Count > 0)
                {
                    var queryString = new StringBuilder("?");
                    foreach (var param in queryParams)
                    {
                        queryString.Append($"{Uri.EscapeDataString(param.Key)}={Uri.EscapeDataString(param.Value)}&");
                    }
                    queryString.Length--; // Remove trailing "&"
                    url += queryString.ToString();
                }

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    responseObject = await JsonSerializer.DeserializeAsync<T>(responseStream);
                }
                else
                {
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}", ex);
            }

            return responseObject;
        }
    }
}
