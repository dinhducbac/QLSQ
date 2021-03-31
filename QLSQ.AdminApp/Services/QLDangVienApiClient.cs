using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.QLDangVien;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class QLDangVienApiClient : IQLDangVienAPIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public QLDangVienApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(QLDangVienCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/QLDangViens/create", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());

        }

        public Task<APIResult<bool>> Edit(int IDQLDV, QLDangVienUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResult<PageResult<QLDangVienViewModel>>> GetAllQLDangVien(GetQLDangVienPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/QLDangViens/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APISuccessedResult<PageResult<QLDangVienViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<QLDangVienViewModel>> GetByID(int IDQLDV)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/QLDangViens/{IDQLDV}/details");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<QLDangVienViewModel>>(body);
            return user;
        }
    }
}
