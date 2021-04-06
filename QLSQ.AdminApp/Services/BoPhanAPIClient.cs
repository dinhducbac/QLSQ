using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class BoPhanAPIClient : IBoPhanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public BoPhanAPIClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(BoPhanCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/BoPhans/create", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());
        }

        public async Task<APIResult<bool>> Delete(int IDBP)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.DeleteAsync($"/api/BoPhans/{IDBP}/delete");
            var body = await reponse.Content.ReadAsStringAsync();
            var bp = JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return bp;
        }

        public async Task<APIResult<BoPhanViewModel>> Details(int IDBP)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/BoPhans/{IDBP}/details");
            var body = await reponse.Content.ReadAsStringAsync();
            var bp = JsonConvert.DeserializeObject<APISuccessedResult<BoPhanViewModel>>(body);
            return bp;
        }

        public async Task<APIResult<bool>> Edit(int IDBP, BoPhanUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/BoPhans/{IDBP}/edit", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());
        }

        public async Task<APIResult<List<BoPhanViewModel>>> GetAllWithNotPaging()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/BoPhans/getall");
            var body = await response.Content.ReadAsStringAsync();
            var list =  JsonConvert.DeserializeObject<APISuccessedResult<List<BoPhanViewModel>>>(body);
            return list;
        }

        public async Task<APIResult<PageResult<BoPhanViewModel>>> GetAllWithPaging(GetBoPhanPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/BoPhans/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APISuccessedResult<PageResult<BoPhanViewModel>>>(body);
            return user;
        }
    }
}
