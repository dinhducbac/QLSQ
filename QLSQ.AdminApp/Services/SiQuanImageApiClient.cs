using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class SiQuanImageApiClient : ISiQuanImageApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public SiQuanImageApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<APIResult<PageResult<SiQuanImageViewModel>>> GetAllWithPaging(GetSiQuanImagePagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/SiQuanImages/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<SiQuanImageViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<SiQuanImageViewModel>>>(body);
        }
    }
}
