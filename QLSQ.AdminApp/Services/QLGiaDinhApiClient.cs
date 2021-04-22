using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class QLGiaDinhApiClient : IQLGiaDinhApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public QLGiaDinhApiClient(IConfiguration configuration,IHttpClientFactory httpClientFactory
            , IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(QLGiaDinhSQCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/QLGiaDinhSQs/create", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<QLGiaDinhSQViewModel>> Details(int IDQLGDSQ)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/QLGiaDinhSQs/{IDQLGDSQ}/details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<QLGiaDinhSQViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<QLGiaDinhSQViewModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int IDQLGDSQ, QLGiaDinhSQUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/QLGiaDinhSQs/{IDQLGDSQ}/edit", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<PageResult<QLGiaDinhSQViewModel>>> GetAllWithPaging(GetQLGiaDinhSQPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/QLGiaDinhSQs/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<QLGiaDinhSQViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<QLGiaDinhSQViewModel>>>(body);
        }
    }
}
