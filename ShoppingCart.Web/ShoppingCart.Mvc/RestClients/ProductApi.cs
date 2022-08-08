using ShoppingCart.Mvc.RestClients;
using ShoppingCart.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.Extensions.Options;
using Refit;
using RestSharp;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microservices10.ShoppingCart.Mvc.Models;

namespace Microservices10.ShoppingCart.Mvc.RestClients
{
    public class ProductApi : IProductApi
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        public ProductApi(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
            string apiHostAndPort = _settings.Value.CatalogApiUrl;
            httpClient.BaseAddress = new Uri($"{apiHostAndPort}/api/product");
        }
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), _httpClient.BaseAddress))
            {
                var response2 = _httpClient.SendAsync(request).Result;

                string test = response2.Content.ReadAsStringAsync().Result;

                productModels = JsonConvert.DeserializeObject<List<ProductModel>>(test);
            }

            return productModels;
        }

        public List<ProductModel> GetPagedProducts(int pagesize, int page)
        {
            List<ProductModel> productModels = new List<ProductModel>();

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), new Uri($"{_httpClient.BaseAddress}/paged?pagesize={pagesize}&page={page}")))
            {
                var response2 = _httpClient.SendAsync(request).Result;

                string test = response2.Content.ReadAsStringAsync().Result;

                productModels = JsonConvert.DeserializeObject<List<ProductModel>>(test);
            }

            return productModels;
        }
    }
}
