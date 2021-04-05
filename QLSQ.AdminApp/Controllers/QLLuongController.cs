using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLLuong;

namespace QLSQ.AdminApp.Controllers
{
    public class QLLuongController : Controller
    {
        private readonly IQLLuongApiClient _qLLuongApiClient;
        public QLLuongController(IQLLuongApiClient qLLuongApiClient)
        {
            _qLLuongApiClient = qLLuongApiClient;
        }
        public async  Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetQLLuongPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLLuongApiClient.GetAllWithPaging(request);
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            return View(result.ResultObj);
        }
    }
}