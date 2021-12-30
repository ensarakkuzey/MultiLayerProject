using MultiLayerProject.Website.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiLayerProject.Website.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            IEnumerable<CategoryDTO> categoryDTOs;

            var response = await _httpClient.GetAsync("categories");

            if (response.IsSuccessStatusCode)
            {
                categoryDTOs = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDTOs = null;
            }

            return categoryDTOs;
        }
    }
}
