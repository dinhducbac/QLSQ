using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLNghiPHep;

namespace QLSQ.AdminApp.Controllers
{
    public class QLNghiPhepController : Controller
    {
        public readonly IQLNghiPhepApiClient _qLNghiPhepApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;

        public QLNghiPhepController(IQLNghiPhepApiClient qLNghiPhepApiClient, ISiQuanApiClient siQuanApiClient) 
        {
            _qLNghiPhepApiClient = qLNghiPhepApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetQLNghiPhepPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLNghiPhepApiClient.GetAllWithPaging(pagingRequest);
            if (result.IsSuccessed)
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
        [HttpGet]
        public async Task<JsonResult> GetListSiQuanAutoComplete(string preconfix)
        {
            var result = await _siQuanApiClient.GetFullListSiQuanAutocomplete(preconfix);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qlnpCreateRequest = new QLNghiPhepCreateRequest()
            {
                ThoiGianBDNP = DateTime.Now,
                ThoiGianKTNP = DateTime.Now
            };
            return View(qlnpCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLNghiPhepCreateRequest request)
        {
            var result = await _qLNghiPhepApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo nghỉ phép thành công!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["result"] = "Tạo nghỉ phép thất bại!";
                return RedirectToAction("Error","Home");
            }
        }
    }
}