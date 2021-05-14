using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QLSQ.ViewModel.Catalogs.SiQuan;
using QLSQ.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QLSQ.ApiIntergration
{
    public class SiQuanApiClient : ISiQuanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SiQuanApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<APIResult<int>> Create(SiQuanCreateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var requestContent = new MultipartFormDataContent();
            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new ByteArrayContent(data);
                requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
            }
            requestContent.Add(new StringContent(request.UserId.ToString()), "UserId");
            requestContent.Add(new StringContent(request.HoTen.ToString()), "HoTen");
            requestContent.Add(new StringContent(request.NgaySinh.ToString()), "NgaySinh");
            requestContent.Add(new StringContent(request.GioiTinh.ToString()), "GioiTinh");
            requestContent.Add(new StringContent(request.QueQuan.ToString()), "QueQuan");
            requestContent.Add(new StringContent(request.SDT.ToString()), "SDT");

            //var json = JsonConvert.SerializeObject(request);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PostAsync($"/api/SiQuans/create", requestContent);
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<int>>(await reponse.Content.ReadAsStringAsync());
            }
            return JsonConvert.DeserializeObject<APIErrorResult<int>>(await reponse.Content.ReadAsStringAsync());

        }

        public async Task<APIResult<string>> Delete(int IDSQ)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.DeleteAsync($"/api/SiQuans/{IDSQ}/delete");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<string>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<string>>(body);
        }

        public async Task<APIResult<PageResult<SiQuanViewModel>>> GetAllManagePaging(GetManageSiQuanPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/SiQuans/manage-paging?pageIndex={request.pageIndex}&pageSize={request.pageSize}&keyword={request.keyword}");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<PageResult<SiQuanViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetAllWithoutPaging()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/SiQuans/getallwithoutpaging");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<List<SiQuanViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<SiQuanViewModel>> GetByID(int IDSQ)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/SiQuans/{IDSQ}/detail");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<SiQuanViewModel>>(body);
            return user;
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetFullListSiQuanAutocomplete(string preconfix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            //var json = JsonConvert.SerializeObject(preconfix);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var reponse = await client.PostAsync($"/api/SiQuans/getlistsiquanautocomplete",httpContent);
            var reponse = await client.GetAsync($"/api/SiQuans/getfulllistsiquanautocomplete?preconfix={preconfix}");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<List<SiQuanViewModel>>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<List<SiQuanViewModel>>>(body);
        }

        public async Task<APIResult<InfoOfJobOfSiQuanViewModel>> GetInfoOfJobOfSiQuan(int IDSQ)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/SiQuans/{IDSQ}/getinfoofjobofsiquan");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<InfoOfJobOfSiQuanViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<InfoOfJobOfSiQuanViewModel>>(body);
        }

        public async Task<APIResult<List<SiQuanInQLLuongViewModel>>> GetListSiQuanAutocomplete(string preconfix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            //var json = JsonConvert.SerializeObject(preconfix);
            //var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            //var reponse = await client.PostAsync($"/api/SiQuans/getlistsiquanautocomplete",httpContent);
            var reponse = await client.GetAsync($"/api/SiQuans/getlistsiquanautocomplete?preconfix={preconfix}");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<List<SiQuanInQLLuongViewModel>>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<List<SiQuanInQLLuongViewModel>>>(body);
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLChucVuAutocomplete(string prefix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/SiQuans/getlistsiquannotinqlchucvuautocomplete?prefix={prefix}");
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<SiQuanViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<SiQuanViewModel>>>(body);
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetListSiQuanNotInQLQuanHamAutocomplete(string prefix)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/SiQuans/getlistsiquannotinqlquanhamautocomplete?prefix={prefix}");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<List<SiQuanViewModel>>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<List<SiQuanViewModel>>>(body);
        }

        public async Task<APIResult<ProfileViewModel>> GetProfileByUserName(string UserName)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var response = await client.GetAsync($"/api/SiQuans/{UserName}/getprofilebyusername");
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<APISuccessedResult<ProfileViewModel>>(body);
            return JsonConvert.DeserializeObject<APIErrorResult<ProfileViewModel>>(body);
        }

        public async Task<APIResult<List<SiQuanViewModel>>> GetSiQuanNotInQLDangVien()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);
            var reponse = await client.GetAsync($"/api/SiQuans/getnotinqldv");
            var body = await reponse.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<APIResult<List<SiQuanViewModel>>>(body);
            return user;
        }

        public async Task<APIResult<bool>> Update(int IDSQ, SiQuanUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", session);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var reponse = await client.PutAsync($"/api/SiQuans/{IDSQ}/update", httpContent);
            var body = await reponse.Content.ReadAsStringAsync();
            if (reponse.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<APISuccessedResult<bool>>(body);
            }
            return JsonConvert.DeserializeObject<APIErrorResult<bool>>(body);
        }
    }
}
