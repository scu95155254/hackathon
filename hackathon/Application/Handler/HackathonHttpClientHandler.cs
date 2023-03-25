using Swifter.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace hackathon.Application.Handler
{
    public sealed class HackathonHttpClientHandler
    {
        private static ObjectCache Cache = MemoryCache.Default;
        //public HackathonHttpClientHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        //{
        //}

        //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //    DateTime logTime = DateTime.Now;
        //    Stopwatch sw = Stopwatch.StartNew();

        //    string traceId;

        //    string token = await GetToken();
        //    request.Headers.Add("Authorization", token);

        //    HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken);
        //    string responseJson = await httpResponseMessage.Content.ReadAsStringAsync();
        //    string httpCode = httpResponseMessage.StatusCode.ToString();
        //    HttpRequestMessage httpRequestMessage = httpResponseMessage.RequestMessage;
        //    string payload = httpRequestMessage.Method == HttpMethod.Get ? httpRequestMessage.RequestUri.Query.Replace("?", "") : await httpRequestMessage.Content.ReadAsStringAsync();
        //    sw.Stop();
        //    int durationTime = Convert.ToInt32(sw.ElapsedMilliseconds);

        //    //RedisQueueHandler.Normal(responseJson, httpCode, httpRequestMessage, payload, logTime, durationTime, httpContext);

        //    return httpResponseMessage;
        //}

        public static async Task<string> GetToken()
        {
            CacheItem tokenCache = Cache.GetCacheItem("token");
            if (tokenCache != null)
            {
                return tokenCache.Value as string;
            }

            string token = await GetExApiToken();

            CacheItemPolicy policy = new CacheItemPolicy()
            {
                SlidingExpiration = new TimeSpan(0, 1, 0)
            };
            tokenCache = new CacheItem("token", token);

            Cache.Set(tokenCache, policy);
            return token;
        }

        private static async Task<string> GetExApiToken()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").ToLowerInvariant();
            string checkNum = (BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(guid + ConfigSettings.ApiKey + ConfigSettings.ApiSecret + DateTime.UtcNow.ToString("HHmmss")))).Replace("-", null) + guid);

            ExApiTokenRequest tokenRequest = new ExApiTokenRequest
            {
                ApiKey = ConfigSettings.ApiKey,
                ApiSecret = ConfigSettings.ApiSecret,
                Checksum = checkNum
            };

            HttpContent content = new StringContent(JsonFormatter.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(ConfigSettings.ExApiTokenDomain, content);
            string responseData = await response.Content.ReadAsStringAsync();
            ExApiResponse<ExApiTokenResponse> exApiResponse = JsonFormatter.DeserializeObject<ExApiResponse<ExApiTokenResponse>>(responseData);
            httpClient.Dispose();
            if (exApiResponse.rCode == "0000")
            {
                return exApiResponse.Data.AccessToken;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}