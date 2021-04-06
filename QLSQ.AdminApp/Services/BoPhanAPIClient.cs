using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.BoPhan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
