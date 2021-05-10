using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.SiQuanImage;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
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

        public async Task<APIResult<bool>> Create(SiQuanImageCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }
            requestContent.Add(new StringContent(request.IDSQ.ToString()), "IDSQ");
            requestContent.Add(new StringContent(request.HoTenSQ.ToString()), "HoTenSQ");
            requestContent.Add(new StringContent(request.Caption.ToString()), "Caption");
            requestContent.Add(new StringContent(request.IsDefault.ToString()), "IsDefault");
            var response = await client.PostAsync($"/api/SiQuanImages/create", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<bool>> Delete(int IDImage)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.DeleteAsync($"/api/SiQuanImages/{IDImage}/delete");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }

        public async Task<APIResult<SiQuanImageViewModel>> Details(int IDImage)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/SiQuanImages/{IDImage}/Details");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<SiQuanImageViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<SiQuanImageViewModel>>(body);
        }

        public async Task<APIResult<bool>> Edit(int IDImage, SiQuanImageUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(request.Caption.ToString()), "Caption");
            requestContent.Add(new StringContent(request.DateCreated.ToString()), "DateCreated");
            requestContent.Add(new StringContent(request.IsDefault.ToString()), "IsDefault");
            if (request.ImageFile != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ImageFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ImageFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ImageFile", request.ImageFile.FileName);
            }
            var response = await client.PutAsync($"/api/SiQuanImages/{IDImage}/edit", requestContent);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);

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
