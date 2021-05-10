using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class RolesApiClient : IRolesApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public RolesApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<APIResult<List<RolesViewModel>>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/Roles");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                List<RolesViewModel> roleReadObj = (List<RolesViewModel>)JsonConvert.DeserializeObject(body, typeof(List<RolesViewModel>));
                return new APISuccessedResult<List<RolesViewModel>>(roleReadObj);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<List<RolesViewModel>>>(body);
        }
    }
}
