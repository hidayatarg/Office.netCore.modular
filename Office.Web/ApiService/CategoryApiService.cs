﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Office.Web.DTOs;
using Newtonsoft.Json;

namespace Office.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDto;

            var response = await _httpClient.GetAsync("category");

            // ** Status Code : 400-404 --> User related, 500-504 --> Server Related,  200-204 ---> Sucess Postive Response
            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert
                    .DeserializeObject<IEnumerable<CategoryDto>>(
                    await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDto = null;
            }
            return categoryDto;
        }
    }
}