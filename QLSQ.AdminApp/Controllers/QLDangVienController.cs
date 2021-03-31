using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLDangVien;

namespace QLSQ.AdminApp.Controllers
{
    public class QLDangVienController : Controller
    {
        public readonly IQLDangVienAPIClient _qLDangVienAPIClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IConfiguration _configuration;

        public QLDangVienController(IQLDangVienAPIClient qLDangVienAPIClient, ISiQuanApiClient siQuanApiClient, IRolesApiClient rolesApiClient, IUserApiClient userApiClient, IConfiguration configuration)
        {
            _qLDangVienAPIClient = qLDangVienAPIClient;
            _siQuanApiClient = siQuanApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetQLDangVienPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLDangVienAPIClient.GetAllQLDangVien(request);
            return View(result.ResultObj);
        }
    }
}