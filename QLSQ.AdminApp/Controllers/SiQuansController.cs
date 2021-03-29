using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.SiQuan;

namespace QLSQ.AdminApp.Controllers
{
    public class SiQuansController : Controller
    {
        public readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IConfiguration _configuration;
        public readonly IRolesApiClient _rolesApiClient;

        public SiQuansController(ISiQuanApiClient siQuanApiClient, IRolesApiClient rolesApiClient, IConfiguration configuration)
        {
            _siQuanApiClient = siQuanApiClient;
            _rolesApiClient = rolesApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetManageSiQuanPagingRequest() {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var data = await _siQuanApiClient.GetAllManagePaging(request);

            return View(data.ResultObj);
        }
    }
}