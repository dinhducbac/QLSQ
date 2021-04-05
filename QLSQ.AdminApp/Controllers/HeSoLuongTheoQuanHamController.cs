using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class HeSoLuongTheoQuanHamController : Controller
    {
        public readonly IHeSoLuongTheoQuanHamApiClient _heSoLuongTheoQuanHamApiClient;
        public HeSoLuongTheoQuanHamController(IHeSoLuongTheoQuanHamApiClient heSoLuongTheoQuanHamApiClient)
        {
            _heSoLuongTheoQuanHamApiClient = heSoLuongTheoQuanHamApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            var paging = new GetPagingRequestHeSoLuongTheoQuanHam()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            var pageresult = await _heSoLuongTheoQuanHamApiClient.GetAllWithPaging(paging);
            return View(pageresult.ResultObj);
        }
    }
}