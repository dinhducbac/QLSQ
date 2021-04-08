using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.Application.Catalog.HeSoPhuCapTHeoChucVu;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class HeSoPhuCapTheoChucVuApiClient : IHeSoPhuCapTheoChucVuApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IHttpClientFactory _httpClientFactory;
        public HeSoPhuCapTheoChucVuApiClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResult<bool>> Create(HeSoPhuCapTheoChucVuCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/HeSoPhuCapTheoChucVus/create", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<HeSoPhuCapTheoChucVuDetailsViewModel>> Details(int IDHeSoPhuCapCV)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/HeSoPhuCapTheoChucVus/{IDHeSoPhuCapCV}/details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<HeSoPhuCapTheoChucVuDetailsViewModel>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<HeSoPhuCapTheoChucVuDetailsViewModel>>(body);
        }

        public async Task<APIResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>> GetAllWithPaging(GetHeSoPhuCapPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/HeSoPhuCapTheoChucVus/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<HeSoPhuCapTheoChucVuViewModel>>>(body);
        }
    }
}
