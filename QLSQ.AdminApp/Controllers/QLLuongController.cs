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
        private readonly ISiQuanApiClient _siQuanApiClient;
        public QLLuongController(IQLLuongApiClient qLLuongApiClient,ISiQuanApiClient siQuanApiClient)
        {
            _qLLuongApiClient = qLLuongApiClient;
            _siQuanApiClient = siQuanApiClient;
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
        [HttpGet]
        public async Task<JsonResult> AutoComplete(string preconfix)
        {
            var listsq = await _siQuanApiClient.GetListSiQuanAutocomplete(preconfix) ;
            //var s = Json(listsq.ResultObj);
            foreach (var data in listsq.ResultObj)
            {
                var s = data.HoTen;
            }
            return Json(listsq.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qllCreateRequest = new QLLuongCreateRequest()
            {
                siQuanViewModels = new List<ViewModel.Catalogs.SiQuan.SiQuanViewModel>()
            };
            var getlistsq = await _siQuanApiClient.GetAllWithoutPaging();
            var listsq = getlistsq.ResultObj;
            qllCreateRequest.siQuanViewModels = listsq;
            return View(qllCreateRequest);
        }
    }
}