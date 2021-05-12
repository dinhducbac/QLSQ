using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.New;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class NewApiClient : INewApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public NewApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(NewCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            if (request.FormFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.FormFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.FormFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "FormFile", request.FormFile.FileName);
            }
            requestContent.Add(new StringContent(request.NewName.ToString()), "NewName");
            requestContent.Add(new StringContent(request.NewContent.ToString()), "NewContent");
            requestContent.Add(new StringContent(request.NewDatePost.ToString()), "NewDatePost");
            requestContent.Add(new StringContent(request.NewCount.ToString()), "NewCount");
            requestContent.Add(new StringContent(request.NewCatetoryID.ToString()), "NewCatetoryID");
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/News/create", requestContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());

        }

        public async Task<APIResult<bool>> Delete(int NewID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"/api/News/{NewID}/delete");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<NewDetailsViewModel>> Details(int NewID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/news/{NewID}/details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<NewDetailsViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<NewDetailsViewModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int NewID, NewUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            if (request.FormFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.FormFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.FormFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "FormFile", request.FormFile.FileName);
            }
            requestContent.Add(new StringContent(request.NewName.ToString()), "NewName");
            requestContent.Add(new StringContent(request.NewContent.ToString()), "NewContent");
            requestContent.Add(new StringContent(request.NewDatePost.ToString()), "NewDatePost");
            requestContent.Add(new StringContent(request.NewCount.ToString()), "NewCount");
            requestContent.Add(new StringContent(request.NewCatetoryID.ToString()), "NewCatetoryID");
            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/News/{NewID}/edit", requestContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(await reponse.Content.ReadAsStringAsync());

        }

        public async Task<APIResult<PageResult<NewViewModel>>> GetAllWithPaging(GetNewPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<NewViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<NewViewModel>>>(body);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetKHCNNewInIndex()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/getkhcnnewinindex");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<NewDetailsViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<NewDetailsViewModel>>>(body);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetLastestNew()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/getlastestnew");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<NewDetailsViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<NewDetailsViewModel>>>(body);
        }

        public async Task<APIResult<List<NewViewModel>>> GetListNewAutoComplete(string prefix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/getlistnewautocomplete?prefix={prefix}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<NewViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<NewViewModel>>>(body);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetMostViewNew()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/getmostviewnew");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<NewDetailsViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<NewDetailsViewModel>>>(body);
        }

        public async Task<APIResult<List<NewDetailsViewModel>>> GetTuyenSinhViewInIndex()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/News/gettuyensinhnewinindex");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<NewDetailsViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<NewDetailsViewModel>>>(body);
        }
    }
}
