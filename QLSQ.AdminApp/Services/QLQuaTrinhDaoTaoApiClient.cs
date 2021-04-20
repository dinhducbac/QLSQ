using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.AdminApp.Services
{
    public class QLQuaTrinhDaoTaoApiClient : IQLQuaTrinhDaoTaoApiClient
    {
        public readonly IConfiguration _configuration;
        public IHttpContextAccessor _httpContextAccessor;
        public IHttpClientFactory _httpClientFactory;
        public QLQuaTrinhDaoTaoApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<APIResult<PageResult<QLQuaTrinhDaoTaoViewModel>>> GetAllWithPaging(GetQLQuaTrinhDaoTaoPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var resonse = await client.GetAsync($"/api/QLQuaTrinhDaoTaos/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await resonse.Content.ReadAsStringAsync();
            if (resonse.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<QLQuaTrinhDaoTaoViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<QLQuaTrinhDaoTaoViewModel>>>(body);
        }
    }
}
