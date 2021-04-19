using FluentValidation.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Common;
using QLSQ.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace QLSQ.AdminApp.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        public UserApiClient(IHttpClientFactory httpClientFactory,IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<APIResult<string>> Authentication(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json"); 
           var client =  _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var reponse = await client.PostAsync("/api/User/authenticate", httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                var session1 = await reponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APISuccessedResult<string>>(session1);

            }
            var session = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(session);
            ;
        }

        public async Task<APIResult<string>> CreateUser(CreateUserRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/User/createuser",httpContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<string>>(await reponse.Content.ReadAsStringAsync());  
            }
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(await reponse.Content.ReadAsStringAsync());

        }

        public async Task<APIResult<string>> DeleteUser(Guid id)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.DeleteAsync($"/api/User/{id}/delete");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<string>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(body);
        }

        public async Task<APIResult<UserViewModel>> GetUserByID(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",session );
            var reponse = await client.GetAsync($"/api/User/{id}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<UserViewModel>>(body);
            return user;
        }
        public async Task<APIResult<UserViewModel>> DetailUser(Guid id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/User/{id}/detail");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<UserViewModel>>(body);
            return user;
        }

        public async Task<APIResult<PageResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/User/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<PageResult<UserViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<string>> UpdateUser(Guid id,UpdateUserRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/User/{id}/update", httpContent);
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {   
                return JsonConvert.DeserializeObject<APISuccessedResult<string>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(body);

        }

        public async  Task<APIResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/User/{id}/roles", httpContent);
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<List<UserViewModel>>> GetAllUser()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/User/getalluser");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<List<UserViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<List<UserViewModel>>> GetListUserAutocomplete(string prefix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/User/getlistuserautocomplete?prefix={prefix}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<UserViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<UserViewModel>>>(body);
        }
    }
}
