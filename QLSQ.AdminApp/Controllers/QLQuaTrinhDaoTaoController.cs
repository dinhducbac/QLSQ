using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.QLQuaTrinhDaoTao;

namespace QLSQ.AdminApp.Controllers
{
    public class QLQuaTrinhDaoTaoController : Controller
    {
        public readonly IQLQuaTrinhDaoTaoApiClient _qLQuaTrinhDaoTaoApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLQuaTrinhDaoTaoController(IQLQuaTrinhDaoTaoApiClient qLQuaTrinhDaoTaoApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _qLQuaTrinhDaoTaoApiClient = qLQuaTrinhDaoTaoApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var qlqtdtPagingRequest = new GetQLQuaTrinhDaoTaoPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLQuaTrinhDaoTaoApiClient.GetAllWithPaging(qlqtdtPagingRequest);
            if (result.ResultObj != null)
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
        public async Task<IActionResult> Create(QLQuaTrinhDaoTaoCreateRequest request)
        {
            var result = await _qLQuaTrinhDaoTaoApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quá trình đào tạo thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQLQTDT)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLQuaTrinhDaoTaoApiClient.Details(IDQLQTDT);
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLQTDT)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlqtdtViewModel = await _qLQuaTrinhDaoTaoApiClient.Details(IDQLQTDT);
            var qlqtdtUpdateRequest = new QLQuaTrinhDaoTaoUpdateRequest()
            {
                IDQLQTDT = qlqtdtViewModel.ResultObj.IDQLQTDT,
                IDSQ = qlqtdtViewModel.ResultObj.IDSQ,
                HoTen = qlqtdtViewModel.ResultObj.HoTen,
                TenTruong = qlqtdtViewModel.ResultObj.TenTruong,
                NganhHoc = qlqtdtViewModel.ResultObj.NganhHoc,
                ThoiGianBDDT = qlqtdtViewModel.ResultObj.ThoiGianBDDT,
                ThoiGianKTDT = qlqtdtViewModel.ResultObj.ThoiGianKTDT,
                HinhThucDT = qlqtdtViewModel.ResultObj.HinhThucDT,
                VanBang = qlqtdtViewModel.ResultObj.VanBang
            };
            return View(qlqtdtUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLQuaTrinhDaoTaoUpdateRequest request)
        {
            var result = await _qLQuaTrinhDaoTaoApiClient.Edit(request.IDQLQTDT, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa quá trình đào tạo thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLQTDT)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlqtdtViewModel = await _qLQuaTrinhDaoTaoApiClient.Details(IDQLQTDT);
            var qlqtdtDeleteRequest = new QLQuaTrinhDaoTaoDeleteRequest()
            {
                IDQLQTDT = qlqtdtViewModel.ResultObj.IDQLQTDT,
                IDSQ = qlqtdtViewModel.ResultObj.IDSQ,
                HoTen = qlqtdtViewModel.ResultObj.HoTen,
                TenTruong = qlqtdtViewModel.ResultObj.TenTruong,
                NganhHoc = qlqtdtViewModel.ResultObj.NganhHoc,
                ThoiGianBDDT = qlqtdtViewModel.ResultObj.ThoiGianBDDT,
                ThoiGianKTDT = qlqtdtViewModel.ResultObj.ThoiGianKTDT,
                HinhThucDT = qlqtdtViewModel.ResultObj.HinhThucDT,
                VanBang = qlqtdtViewModel.ResultObj.VanBang
            };
            return View(qlqtdtDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLQuaTrinhDaoTaoDeleteRequest request)
        {
            var result = await _qLQuaTrinhDaoTaoApiClient.Delete(request.IDQLQTDT);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa quá trình đào tạo thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}