using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.ChucVu;
using QLSQ.ViewModel.Catalogs.HeSoPhuCapTheoChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class HeSoPhuCapTheoChucVuController : Controller
    {
        public readonly IHeSoPhuCapTheoChucVuApiClient _heSoPhuCapTheoChucVuApiClient;
        public readonly IBoPhanApiClient _boPhanApiClient;
        public readonly IChucVuApiClient _chucVuApiClient;
        public HeSoPhuCapTheoChucVuController(IHeSoPhuCapTheoChucVuApiClient heSoPhuCapTheoChucVuApiClient, IBoPhanApiClient boPhanApiClient,
            IChucVuApiClient chucVuApiClient)
        {
            _heSoPhuCapTheoChucVuApiClient = heSoPhuCapTheoChucVuApiClient;
            _boPhanApiClient = boPhanApiClient;
            _chucVuApiClient = chucVuApiClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var cvPagingRequest = new GetHeSoPhuCapPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _heSoPhuCapTheoChucVuApiClient.GetAllWithPaging(cvPagingRequest);
            if (result.IsSuccessed)
            {
                if (ViewData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = ViewData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var hspcCreateRequest = new HeSoPhuCapTheoChucVuCreateRequest()
            {
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>(),
                chucVuViewModels = new List<ViewModel.Catalogs.ChucVu.ChucVuViewModel>()
            };
            var getListBP = await _boPhanApiClient.GetAllWithNotPaging();
            var listBP = getListBP.ResultObj;
            hspcCreateRequest.boPhanViewModels = listBP;
            var getListCV = await _chucVuApiClient.GetChucVuWithIDBP(1);
            var listCV = getListCV.ResultObj;
            hspcCreateRequest.chucVuViewModels = listCV;
            return View(hspcCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(HeSoPhuCapTheoChucVuCreateRequest request)
        {
            var test = request.IDCV;
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoPhuCapTheoChucVuApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo hệ số phụ cấp thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error","Home");
        }
        [HttpGet]
        public async  Task<IActionResult> getCV(int IDBP)
        {
            List<ChucVuViewModel> list = new List<ChucVuViewModel>();
            var getListCV = await _chucVuApiClient.GetChucVuWithIDBP(IDBP);
            list = getListCV.ResultObj;
            return Json(new SelectList(list, "IDCV", "TenCV"));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int IDHeSoPhuCapCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _heSoPhuCapTheoChucVuApiClient.Details(IDHeSoPhuCapCV);
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDHeSoPhuCapCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var hspc = await _heSoPhuCapTheoChucVuApiClient.Details(IDHeSoPhuCapCV);
            var hspcUpdateRequest = new HeSoPhuCapTheoChucVuUpdateRequest()
            {
                IDHeSoPhuCapCV = hspc.ResultObj.IDHeSoPhuCapCV,
                IDBP = hspc.ResultObj.IDBP,
                IDCV = hspc.ResultObj.IDCV,
                HeSoPhuCap = hspc.ResultObj.HeSoPhuCap,
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>(),
                chucVuViewModels = new List<ChucVuViewModel>()
            };
            var getListBP = await _boPhanApiClient.GetAllWithNotPaging();
            hspcUpdateRequest.boPhanViewModels = getListBP.ResultObj;
            var getListCV = await _chucVuApiClient.GetChucVuWithIDBP(hspc.ResultObj.IDBP);
            hspcUpdateRequest.chucVuViewModels = getListCV.ResultObj;
            return View(hspcUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HeSoPhuCapTheoChucVuUpdateRequest request)
        {
            var result = await _heSoPhuCapTheoChucVuApiClient.Edit(request.IDHeSoPhuCapCV, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa hệ số phu cấp thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDHeSoPhuCapCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var hspc = await _heSoPhuCapTheoChucVuApiClient.Details(IDHeSoPhuCapCV);
            var hspcDeleteRequest = new HeSoPhuCapTheoChucVuDeleteRequest()
            {
                IDHeSoPhuCapCV = hspc.ResultObj.IDHeSoPhuCapCV,
                IDBP = hspc.ResultObj.IDBP,
                TenBP = hspc.ResultObj.TenBP,
                IDCV = hspc.ResultObj.IDCV,
                TenCV = hspc.ResultObj.TenCV,
                HeSoPhuCap = hspc.ResultObj.HeSoPhuCap
            };
            return View(hspcDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HeSoPhuCapTheoChucVuDeleteRequest request)
        {
            var result = await _heSoPhuCapTheoChucVuApiClient.Delete(request.IDHeSoPhuCapCV);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa phụ cấp thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }

    }
}