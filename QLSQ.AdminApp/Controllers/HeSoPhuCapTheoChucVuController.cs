using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    }
}