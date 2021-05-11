using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.NewCatetory;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class NewCatetoryApiClient : INewCatetoryApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public NewCatetoryApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(NewCatetoryCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/NewCatetorys/create", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<bool>> Delete(int NewCatetoryID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"/api/NewCatetorys/{NewCatetoryID}/delete");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<NewCatetoryViewModel>> Details(int NewCatetoryID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/NewCatetorys/{NewCatetoryID}/details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<NewCatetoryViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<NewCatetoryViewModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int NewCatetoryID, NewCatetoryUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/NewCatetorys/{NewCatetoryID}/edit", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<PageResult<NewCatetoryViewModel>>> GetAllWithPaging(GetNewCatetoryPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/NewCatetorys/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<NewCatetoryViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<NewCatetoryViewModel>>>(body);
        }
    }
}
