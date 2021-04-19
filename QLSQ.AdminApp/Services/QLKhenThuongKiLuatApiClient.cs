using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
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
