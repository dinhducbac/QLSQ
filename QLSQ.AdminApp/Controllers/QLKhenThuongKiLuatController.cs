using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalog.QLKhenThuongKiLuat;
using QLSQ.ViewModel.Catalogs.QLKhenThuongKiLuat;

namespace QLSQ.AdminApp.Controllers
{
    public class QLKhenThuongKiLuatController : Controller
    {
        public readonly IQLKhenThuongKiLuatApiClient _qLKhenThuongKiLuatApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLKhenThuongKiLuatController(IQLKhenThuongKiLuatApiClient qLKhenThuongKiLuatApiClient
            , ISiQuanApiClient siQuanApiClient)
        {
            _qLKhenThuongKiLuatApiClient = qLKhenThuongKiLuatApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var pagingRequest = new GetQLKhenThuongKiLuatPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLKhenThuongKiLuatApiClient.GetAllWithPaging(pagingRequest);
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
        public async Task<JsonResult> GetListSiQuanAutocomplete(string preconfix)
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
        public async Task<IActionResult> Create(QLKhenThuongKiLuatCreateRequest request)
        {
            var result = await _qLKhenThuongKiLuatApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo khen thưởng kỉ luật thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQLKTKL)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLKhenThuongKiLuatApiClient.Details(IDQLKTKL);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLKTKL)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlktklViewModel = await _qLKhenThuongKiLuatApiClient.Details(IDQLKTKL);
            var qlktklUpdateRequest = new QLKhenThuongKiLuatUpdateRequest()
            {
                IDQLKTKL = qlktklViewModel.ResultObj.IDQLKTKL,
                IDSQ = qlktklViewModel.ResultObj.IDSQ,
                HoTen = qlktklViewModel.ResultObj.HoTen,
                NgayThucHien = qlktklViewModel.ResultObj.NgayThucHien,
                LoaiKTKL = qlktklViewModel.ResultObj.LoaiKTKL,
                HinhThuc = qlktklViewModel.ResultObj.HinhThuc,
                DonViCap = qlktklViewModel.ResultObj.DonViCap,
                NoiDung = qlktklViewModel.ResultObj.NoiDung
            };
            return View(qlktklUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLKhenThuongKiLuatUpdateRequest request)
        {
            var result = await _qLKhenThuongKiLuatApiClient.Edit(request.IDQLKTKL, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa khen thưởng/kỉ luật thành công";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLKTKL)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlktklViewModel = await _qLKhenThuongKiLuatApiClient.Details(IDQLKTKL);
            var qlktklDeleteRequest = new QLKhenThuongKiLuatDeleteRequest()
            {
                IDQLKTKL = qlktklViewModel.ResultObj.IDQLKTKL,
                IDSQ = qlktklViewModel.ResultObj.IDSQ,
                HoTen = qlktklViewModel.ResultObj.HoTen,
                NgayThucHien = qlktklViewModel.ResultObj.NgayThucHien,
                LoaiKTKL = qlktklViewModel.ResultObj.LoaiKTKL,
                HinhThuc = qlktklViewModel.ResultObj.HinhThuc,
                DonViCap = qlktklViewModel.ResultObj.DonViCap,
                NoiDung = qlktklViewModel.ResultObj.NoiDung
            };
            return View(qlktklDeleteRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLKhenThuongKiLuatDeleteRequest request)
        {
            var result = await _qLKhenThuongKiLuatApiClient.Delete(request.IDQLKTKL);
            if (result.ResultObj == true)
            {
                TempData["result"] = "Xóa khen thưởng kỉ luật thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}