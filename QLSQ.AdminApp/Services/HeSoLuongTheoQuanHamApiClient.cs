using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class HeSoLuongTheoQuanHamApiClient : IHeSoLuongTheoQuanHamApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public HeSoLuongTheoQuanHamApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> CheckNameHeSoLuongInCreate(string name)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(name);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/HeSoLuongTheoQuanHams/checkname", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<bool>> Create(HeSoLuongTheoQuanHamCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/HeSoLuongTheoQuanHams/create", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());
        }

        public async Task<APIResult<bool>> Delete(int IDHeSoLuongQH)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.DeleteAsync($"/api/HeSoLuongTheoQuanHams/{IDHeSoLuongQH}/delete");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<HeSoLuongTheoQuanHamViewModel>> Details(int IDHeSoLuongQH)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/HeSoLuongTheoQuanHams/{IDHeSoLuongQH}/details");
            var body = await reponse.Content.ReadAsStringAsync();
            var details = JsonConvert.DeserializeObject<APISuccessedResult<HeSoLuongTheoQuanHamViewModel>>(body);
            return details;
        }

        public async Task<APIResult<bool>> Edit(int IDHeSoLuongQH, HeSoLuongTheoQuanHamUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/HeSoLuongTheoQuanHams/{IDHeSoLuongQH}/edit", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());
        }

        public async Task<APIResult<PageResult<HeSoLuongTheoQuanHamViewModel>>> GetAllWithPaging(GetPagingRequestHeSoLuongTheoQuanHam request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/HeSoLuongTheoQuanHams/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APISuccessedResult<PageResult<HeSoLuongTheoQuanHamViewModel>>>(body);
            return user;
        }
    }
}
