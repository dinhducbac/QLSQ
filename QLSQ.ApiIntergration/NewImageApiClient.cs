using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.NewImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class NewImageApiClient : INewImageApiClient
    {
        public readonly IConfiguration _configuration;
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public NewImageApiClient(IConfiguration configuration, IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<bool>> Create(NewImageCreateRequest request)
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
            requestContent.Add(new StringContent(request.NewID.ToString()), "NewID");
            var response = await client.PostAsync($"/api/NewImages/create", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<bool>> Delete(int NewImageID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"/api/NewImages/{NewImageID}/delete");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<NewImageDetailsModel>> Details(int NewImageID)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/NewImages/{NewImageID}/details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<NewImageDetailsModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<NewImageDetailsModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int NewImageID, NewImageUpdateRequest request)
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
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "FormFile", request.FormFile.FileName);
                }

            }
            requestContent.Add(new StringContent(request.DateCreated.ToString()), "DateCreated");
            var response = await client.PutAsync($"/api/NewImages/{NewImageID}/edit", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<PageResult<NewImageViewModel>>> GetAllWithPaging(GetNewImagePagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/NewImages/paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<PageResult<NewImageViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<PageResult<NewImageViewModel>>>(body);
        }
    }
}
