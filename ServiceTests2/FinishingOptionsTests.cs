using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Talon.Web.Models.Get;
using Taylor.UFP.XCore.Common.Models.Pagination;
using Xunit;

namespace ServiceTests2
{
    public class FinishingOptionsTests
    {
        private readonly string token;

        public FinishingOptionsTests()
        {
            Console.WriteLine("FinishingOptionsTests is created");
            token = GetToken(23910).Result;
        }

        [Fact]
        public async Task GetFinishiOption_Success()
        {
            // Arrange
            var token2 = GetToken(23910).Result;

            var id = 12345;
            var url = $"http://talonsvcdev.navitor.com/api/FinishingOptions/{id}";

            // Act
            var result = await GetObject<PagedData<GetFinishingOptionPayload>>("http://talonsvcdev.navitor.com/api/FinishingOptions/132");

            var id2 = DateTime.UtcNow;

            // Assert
            Assert.NotNull(result);
        }

        private async Task<string> GetToken(int accountId)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(Settings.UserName, Settings.Pwd, Settings.DomainName)
            };

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"https://upadmindev.navitor.com/api/JmeterApi/{accountId}"),
                    Method = HttpMethod.Get
                };
                var resultResponse = await httpClient.SendAsync(request);
                if (resultResponse.IsSuccessStatusCode)
                {
                    var resContent = await resultResponse.Content.ReadAsStringAsync();
                    return resContent.Replace("\"", "");
                }
                return string.Empty;
            }

        }

        private async Task<T> GetObject<T>(string url) where T: new()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using (var httpClient = new HttpClient())
            {
                var resultResponse = await httpClient.SendAsync(request);
                if (resultResponse.StatusCode == HttpStatusCode.OK)
                {
                    var rescontent = await resultResponse.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(rescontent);
                }
                return default(T);
            }
        }
    }
}
