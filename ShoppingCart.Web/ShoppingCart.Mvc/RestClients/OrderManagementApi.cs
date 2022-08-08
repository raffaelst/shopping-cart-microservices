
using Microservices10.ShoppingCart.Mvc.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ShoppingCart.Mvc.RestClients
{
    public class OrderManagementApi : IOrderManagementApi
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        public OrderManagementApi(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            string apiHostAndPort = _settings.Value.OrdersApiUrl;
            httpClient.BaseAddress = new Uri($"{apiHostAndPort}/api/orders");
        }

        public void CreateOrder(List<CheckoutItemModel> checkoutItemModels)
        {
            using (var request = new HttpRequestMessage(new HttpMethod("POST"), _httpClient.BaseAddress))
            {
                var jsonSettings = new JsonSerializerSettings();
                jsonSettings.Culture = System.Globalization.CultureInfo.InvariantCulture;
                jsonSettings.MissingMemberHandling = MissingMemberHandling.Ignore;

                string content = JsonConvert.SerializeObject(checkoutItemModels, jsonSettings);

                request.Content = new StringContent(content);
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var response2 = _httpClient.SendAsync(request).Result;

                string test = response2.Content.ReadAsStringAsync().Result;

                //productModels = JsonConvert.DeserializeObject<List<ProductModel>>(test);
            }
        }

    }
}
