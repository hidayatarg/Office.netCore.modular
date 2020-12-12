using System;
using System.Net.Http;

namespace Office.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
