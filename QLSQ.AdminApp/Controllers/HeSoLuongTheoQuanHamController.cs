using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.HeSoLuongTheoQuanHam;
using QLSQ.ViewModel.Catalogs.QuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class HeSoLuongTheoQuanHamController : Controller
    {
        public readonly IHeSoLuongTheoQuanHamApiClient _heSoLuongTheoQuanHamApiClient;
        public readonly IQuanHamApiClient _quanHamApiClient;
        public HeSoLuongTheoQuanHamController(IHeSoLuongTheoQuanHamApiClient heSoLuongTheoQuanHamApiClient, IQuanHamApiClient quanHamApiClient)
        {
            _heSoLuongTheoQuanHamApiClient = heSoLuongTheoQuanHamApiClient;
            _quanHamApiClient = quanHamApiClient;
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
        [HttpPost]
        public ActionResult SetViewBag(bool check)
        {
            ViewBag.CheckName = check;
            var test = ViewBag.CheckName;
            return  Json(ViewBag.CheckName);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createRequest = new HeSoLuongTheoQuanHamCreateRequest()
            {
                quanHamViewModels = new List<QuanHamViewModel>()
            };
            var getqh = await _quanHamApiClient.GetAllWithoutPaging();
            var qh = getqh.ResultObj;
            createRequest.quanHamViewModels = qh.ToList();
            return View(createRequest);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(HeSoLuongTheoQuanHamCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoLuongTheoQuanHamApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo hệ số lương thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror", "Home");
        }
        [HttpPost] 
        public async Task<IActionResult> CheckNameHeSoLuongInCreate(string name)
        {
            bool check = false;
            var result = await _heSoLuongTheoQuanHamApiClient.CheckNameHeSoLuongInCreate(name);     
            if (result.IsSuccessed)
            {
                //ViewBag.CheckName = false;
                check = true;
                return Json(check);
            }
            //ViewBag.CheckName = true;
            return Json(check);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDHeSoLuongQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoLuongTheoQuanHamApiClient.Details(IDHeSoLuongQH);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDHeSoLuongQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var hslvm = await _heSoLuongTheoQuanHamApiClient.Details(IDHeSoLuongQH);
            if (hslvm.IsSuccessed)
            {
                var hslUpdateRequest = new HeSoLuongTheoQuanHamUpdateRequest()
                {
                    IDHeSoLuongQH = hslvm.ResultObj.IDHeSoLuongQH,
                    IDQH = hslvm.ResultObj.IDQH,
                    TenQH = hslvm.ResultObj.TenQH,
                    TenHeSoLuongQH = hslvm.ResultObj.TenHeSoLuongQH,
                    HeSoLuong = hslvm.ResultObj.HeSoLuong
                };
                return View(hslUpdateRequest);
            }
            return View(hslvm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HeSoLuongTheoQuanHamUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoLuongTheoQuanHamApiClient.Edit(request.IDHeSoLuongQH, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa hệ số lương thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDHeSoLuongQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var hslvm = await _heSoLuongTheoQuanHamApiClient.Details(IDHeSoLuongQH);
            if (hslvm.IsSuccessed)
            {
                var hslDeleteRequest = new HeSoLuongTheoQuanHamDeleteRequest()
                {
                    IDHeSoLuongQH = hslvm.ResultObj.IDHeSoLuongQH,
                    IDQH = hslvm.ResultObj.IDQH,
                    TenQH = hslvm.ResultObj.TenQH,
                    TenHeSoLuongQH = hslvm.ResultObj.TenHeSoLuongQH,
                    HeSoLuong = hslvm.ResultObj.HeSoLuong
                };
                return View(hslDeleteRequest);
            }
            return View(hslvm);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HeSoLuongTheoQuanHamDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoLuongTheoQuanHamApiClient.Delete(request.IDHeSoLuongQH);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa hệ số lương thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}