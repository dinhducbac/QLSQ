using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.ChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class ChucVuController : Controller
    {
        public readonly IChucVuApiClient _chucVuApiClient;
        public ChucVuController(IChucVuApiClient chucVuApiClient)
        {
            _chucVuApiClient = chucVuApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetChucVuPagingRequest()
            {
                keword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _chucVuApiClient.GetAllWithPaging(pagingRequest);
            if (result.ResultObj != null)
            {
                if(TempData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
    }
}