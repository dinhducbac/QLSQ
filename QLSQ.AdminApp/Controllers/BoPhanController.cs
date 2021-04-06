using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.BoPhan;

namespace QLSQ.AdminApp.Controllers
{
    public class BoPhanController : Controller
    {
        public readonly IBoPhanApiClient _boPhanApiClient;
        public BoPhanController(IBoPhanApiClient boPhanApiClient)
        {
            _boPhanApiClient = boPhanApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            var pagingRequest = new GetBoPhanPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _boPhanApiClient.GetAllWithPaging(pagingRequest);
            if (result.ResultObj != null)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}