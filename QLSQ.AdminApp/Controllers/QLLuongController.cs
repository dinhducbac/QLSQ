using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
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
            return Json(listsq.ResultObj);
        }
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLLuongCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLLuongApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quản lý lương thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDLuong)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLLuongApiClient.Details(IDLuong);
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet] 
        public async Task<IActionResult> Delete(int IDLuong)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qllDetailsModel = await _qLLuongApiClient.Details(IDLuong);
            var qllDeleteRequest = new QLLuongDeleteRequest()
            {
                IDLuong = qllDetailsModel.ResultObj.IDLuong,
                IDSQ = qllDetailsModel.ResultObj.IDSQ,
                HoTen = qllDetailsModel.ResultObj.HoTen,
                IDQH = qllDetailsModel.ResultObj.IDQH,
                TenQH = qllDetailsModel.ResultObj.TenQH,
                IDHeSoLuongQH = qllDetailsModel.ResultObj.IDHeSoLuongQH,
                HeSoLuongQH = qllDetailsModel.ResultObj.HeSoLuongQH,
                IDCV = qllDetailsModel.ResultObj.IDCV,
                TenCV = qllDetailsModel.ResultObj.TenCV,
                IDHeSoPhuCapCV = qllDetailsModel.ResultObj.IDHeSoPhuCapCV,
                HeSoPhuCapCV = qllDetailsModel.ResultObj.HeSoPhuCapCV,
                IDLuongCB = qllDetailsModel.ResultObj.IDLuongCB,
                LuongCB = qllDetailsModel.ResultObj.LuongCB,
                Luong = qllDetailsModel.ResultObj.Luong
            };
            return View(qllDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLLuongDeleteRequest request)
        {
            var result = await _qLLuongApiClient.Delete(request.IDLuong);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa quản lý lương thành cồng!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        
    }
}