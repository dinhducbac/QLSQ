using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.QLGiaDinhSQ;

namespace QLSQ.AdminApp.Controllers
{
    public class QLGiaDinhSQController : Controller
    {
        public readonly IQLGiaDinhApiClient _qLGiaDinhApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLGiaDinhSQController(IQLGiaDinhApiClient qLGiaDinhApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _qLGiaDinhApiClient = qLGiaDinhApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            var qlgdsqPagingRequest = new GetQLGiaDinhSQPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLGiaDinhApiClient.GetAllWithPaging(qlgdsqPagingRequest);
            if (result.IsSuccessed)
            {
                if (TempData["result"] != null)
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLGiaDinhSQCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLGiaDinhApiClient.Create(request);
            if(result.ResultObj == true)
            {
                TempData["result"] = "Tạo quản lý gia đình sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQLGDSQ)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLGiaDinhApiClient.Details(IDQLGDSQ);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLGDSQ)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLGiaDinhApiClient.Details(IDQLGDSQ);
            if (result.ResultObj != null)
            {
                var qlgdsqUpdateRequest = new QLGiaDinhSQUpdateRequest()
                {
                    IDQLGDSQ = result.ResultObj.IDQLGDSQ,
                    IDSQ = result.ResultObj.IDSQ,
                    HoTenSQ = result.ResultObj.HoTenSQ,
                    QuanHe = result.ResultObj.QuanHe,
                    HoTen = result.ResultObj.HoTen,
                    NgaySinh = result.ResultObj.NgaySinh,
                    GhiChu = result.ResultObj.GhiChu
                };
                return View(qlgdsqUpdateRequest);
            }            
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLGiaDinhSQUpdateRequest request)
        {
            var result = await _qLGiaDinhApiClient.Edit(request.IDQLGDSQ, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa quản lý gia đình sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLGDSQ)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var getqlgdsqViewModel = await _qLGiaDinhApiClient.Details(IDQLGDSQ);
            var qlgdsqDeleteRequest = new QLGiaDinhSQDeleteRequest()
            {
                IDQLGDSQ = getqlgdsqViewModel.ResultObj.IDQLGDSQ,
                IDSQ = getqlgdsqViewModel.ResultObj.IDSQ,
                HoTenSQ = getqlgdsqViewModel.ResultObj.HoTenSQ,
                QuanHe = getqlgdsqViewModel.ResultObj.QuanHe,
                HoTen = getqlgdsqViewModel.ResultObj.HoTen,
                NgaySinh = getqlgdsqViewModel.ResultObj.NgaySinh,
                GhiChu = getqlgdsqViewModel.ResultObj.GhiChu
            };
            return View(qlgdsqDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLGiaDinhSQDeleteRequest request)
        {
            var result = await _qLGiaDinhApiClient.Delete(request.IDQLGDSQ);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa gia đình sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}