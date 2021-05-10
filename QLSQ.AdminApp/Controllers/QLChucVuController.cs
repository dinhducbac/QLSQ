using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.QLChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class QLChucVuController : Controller
    {
        public readonly IQLChucVuApiClient _qLChucVuApiClient;
        private readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IBoPhanApiClient _boPhanApiClient;
        public readonly IChucVuApiClient _chucVuApiClient;
        public readonly IHeSoPhuCapTheoChucVuApiClient _heSoPhuCapTheoChucVuApiClient;

        public QLChucVuController(IQLChucVuApiClient qLChucVuApiClient, IBoPhanApiClient boPhanApiClient,
            IChucVuApiClient chucVuApiClient, ISiQuanApiClient siQuanApiClient, IHeSoPhuCapTheoChucVuApiClient heSoPhuCapTheoChucVuApiClient)
        {
            _qLChucVuApiClient = qLChucVuApiClient;         
            _boPhanApiClient = boPhanApiClient;
            _chucVuApiClient = chucVuApiClient;
            _siQuanApiClient = siQuanApiClient;
            _heSoPhuCapTheoChucVuApiClient = heSoPhuCapTheoChucVuApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex =1, int pageSize = 5)
        {
            var qlcvPagingRequest = new GetQLChucVuPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLChucVuApiClient.GetAllWithPaging(qlcvPagingRequest);
            if (TempData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = TempData["result"];
            }
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<JsonResult> Autocomplete(string prefix)
        {
            var listsq = await _siQuanApiClient.GetListSiQuanNotInQLChucVuAutocomplete(prefix);           
            return Json(listsq.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var qlcvCreateRequest = new QLChucVuCreateRequest()
            {
                quanHamViewModels = new List<ViewModel.Catalogs.QuanHam.QuanHamViewModel>(),
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>(),
                chucVuViewModels = new List<ViewModel.Catalogs.ChucVu.ChucVuViewModel>()
            };          
            var getListBoPhan = await _boPhanApiClient.GetAllWithNotPaging();
            qlcvCreateRequest.boPhanViewModels = getListBoPhan.ResultObj;
            var getLiChucVu = await _chucVuApiClient.GetChucVuWithIDBP(1);
            qlcvCreateRequest.chucVuViewModels = getLiChucVu.ResultObj;
            return View(qlcvCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Create(QLChucVuCreateRequest request)
        {
            var result = await _qLChucVuApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quản lý chức vụ sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQLCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLChucVuApiClient.Details(IDQLCV);
            if (result.IsSuccessed)
            {
                return View(result.ResultObj);
            }                   
            return View(result);
        }
        [HttpGet]
        public async Task<JsonResult> GetHeSoPhuCapByIDCV(int IDCV)
        {
            var result = await _heSoPhuCapTheoChucVuApiClient.GetHeSoPhuCapByIDCV(IDCV);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLCV)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLChucVuApiClient.Details(IDQLCV);
            var qlcvUpdateRequest = new QLChucVuUpdateRequest()
            {
                IDQLCV = result.ResultObj.IDQLCV,
                IDSQ = result.ResultObj.IDSQ,
                HoTen = result.ResultObj.HoTen,
                IDBP = result.ResultObj.IDBP,
                IDCV = result.ResultObj.IDCV,
                NgayNhan = result.ResultObj.NgayNhan,
                HeSoPhuCap = result.ResultObj.HeSoPhuCap,
                boPhanViewModels = new List<ViewModel.Catalogs.BoPhan.BoPhanViewModel>(),
                chucVuViewModels = new List<ViewModel.Catalogs.ChucVu.ChucVuViewModel>()
            };
            var getListBoPhan = await _boPhanApiClient.GetAllWithNotPaging();
            qlcvUpdateRequest.boPhanViewModels = getListBoPhan.ResultObj;
            var getLiChucVu = await _chucVuApiClient.GetChucVuWithIDBP(qlcvUpdateRequest.IDBP);
            qlcvUpdateRequest.chucVuViewModels = getLiChucVu.ResultObj;
            return View(qlcvUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLChucVuUpdateRequest request)
        {
            var result = await _qLChucVuApiClient.Edit(request.IDQLCV, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa quản lý chức vụ thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLCV)
        {
            var qlcvDetailsViewModel = await _qLChucVuApiClient.Details(IDQLCV);
            var qlcvDeleteRequest = new QLChucVuDeleteRequest()
            {
                IDQLCV = qlcvDetailsViewModel.ResultObj.IDQLCV,
                IDSQ = qlcvDetailsViewModel.ResultObj.IDSQ,
                HoTen = qlcvDetailsViewModel.ResultObj.HoTen,
                IDBP = qlcvDetailsViewModel.ResultObj.IDBP,
                TenBP = qlcvDetailsViewModel.ResultObj.TenBP,
                IDCV = qlcvDetailsViewModel.ResultObj.IDCV,
                TenCV = qlcvDetailsViewModel.ResultObj.TenCV,
                NgayNhan = qlcvDetailsViewModel.ResultObj.NgayNhan,
                HeSoPhuCap = qlcvDetailsViewModel.ResultObj.HeSoPhuCap
            };
            return View(qlcvDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLChucVuDeleteRequest request)
        {
            var result = await _qLChucVuApiClient.Delete(request.IDQLCV);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa chức vụ của sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}