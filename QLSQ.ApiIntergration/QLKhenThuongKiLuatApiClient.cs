using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class QLKhenThuongKiLuatApiClient : IQLKhenThuongKiLuatApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public QLKhenThuongKiLuatApiClient(IConfiguration configuration, IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResult<bool>> Create(QLKhenThuongKiLuatCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/QLKhenTHuongKiLuats/create", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<bool>> Delete(int IDQLKTKL)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"/api/QLKhenThuongKiLuats/{IDQLKTKL}/delete");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<QLKhenThuongKiLuatViewModel>> Details(int IDQLKTKL)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var resonse = await client.GetAsync($"/api/QLKhenThuongKiLuats/{IDQLKTKL}/details");
            var body = await resonse.Content.ReadAsStringAsync();
            if (resonse.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<QLKhenThuongKiLuatViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<QLKhenThuongKiLuatViewModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int IDQLKTKL, QLKhenThuongKiLuatUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/QLKhenThuongKiLuats/{IDQLKTKL}/edit", httpContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<PageResult<QLKhenThuongKiLuatViewModel>>> GetAllWithPaging(GetQLKhenThuongKiLuatPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var resonse = await client.GetAsync($"/api/QLKhenThuongKiLuats/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await resonse.Content.ReadAsStringAsync();
            if (resonse.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<QLKhenThuongKiLuatViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<QLKhenThuongKiLuatViewModel>>>(body);
        }
    }
}
