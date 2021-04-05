using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class QuanHamController : Controller
    {
        public readonly IConfiguration _configuration;
        public readonly IQuanHamApiClient _quanHamApiClient;
        public QuanHamController(IQuanHamApiClient quanHamApiClient,IConfiguration configuration )
        {
            _quanHamApiClient = quanHamApiClient;
            _configuration = configuration;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize  = 10)
        {
            var request = new GetQuanHamPagingRequest()
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
            var result = await _quanHamApiClient.GetAllWithPaging(request);
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _quanHamApiClient.Details(IDQH);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuanHamCreateRequest request)
        {
            var result = await _quanHamApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quân hàm thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qhvm = await _quanHamApiClient.Details(IDQH);
            if(qhvm.ResultObj != null)
            {
                var qhUpdateRequest = new QuanHamUpdateRequest()
                {
                    IDQH = qhvm.ResultObj.IDQH,
                    TenQH = qhvm.ResultObj.TenQH
                };
                return View(qhUpdateRequest);
            }
            return View(qhvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QuanHamUpdateRequest request)
        {
            var qhEdit = await _quanHamApiClient.Edit(request.IDQH,request);
            if (qhEdit.IsSuccessed)
            {
                TempData["result"] = "Chỉnh sửa quân hàm thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror","Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQH)
        {
            var qhvm = await _quanHamApiClient.Details(IDQH);
            if (qhvm.ResultObj != null)
            {
                var qhDeleteRequest = new QuanHamDeleteRequest()
                {
                    IDQH = qhvm.ResultObj.IDQH,
                    TenQH = qhvm.ResultObj.TenQH
                };
                return View(qhDeleteRequest);
            }
            return View(qhvm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QuanHamDeleteRequest request)
        {
            var test = request.IDQH;
            var qhdelete = await _quanHamApiClient.Delete(request.IDQH,request);
            if (qhdelete.IsSuccessed)
            {
                TempData["result"] = "Xóa quân hàm thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror", "Home");
        }
    }
}