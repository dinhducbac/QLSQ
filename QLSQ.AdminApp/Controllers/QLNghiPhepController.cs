﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
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
        public  IActionResult Create()
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
                return RedirectToAction("Error", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDNP)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLNghiPhepApiClient.Details(IDNP);
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDNP)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlnpDetails = await _qLNghiPhepApiClient.Details(IDNP);
            var qlnpUpdateRequest = new QLNghiPhepUpdateRequest()
            {
                IDNP = qlnpDetails.ResultObj.IDNP,
                IDSQ = qlnpDetails.ResultObj.IDSQ,
                HoTen = qlnpDetails.ResultObj.HoTen,
                ThoiGianBDNP = qlnpDetails.ResultObj.ThoiGianBDNP,
                ThoiGianKTNP = qlnpDetails.ResultObj.ThoiGianKTNP,
                NghiPhepState = qlnpDetails.ResultObj.NghiPhepState
            };
            return View(qlnpUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLNghiPhepUpdateRequest request)
        {
            var result = await _qLNghiPhepApiClient.Edit(request.IDNP, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa nghỉ phép thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDNP)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlnpViewModel = await _qLNghiPhepApiClient.Details(IDNP);
            var qlnpDeleteRequest = new QLNghiPhepDeleteRequest()
            {
                IDNP = qlnpViewModel.ResultObj.IDNP,
                IDSQ = qlnpViewModel.ResultObj.IDSQ,
                HoTen = qlnpViewModel.ResultObj.HoTen,
                ThoiGianBDNP = qlnpViewModel.ResultObj.ThoiGianBDNP,
                ThoiGianKTNP = qlnpViewModel.ResultObj.ThoiGianKTNP,
                NghiPhepState = qlnpViewModel.ResultObj.NghiPhepState
            };
            return View(qlnpDeleteRequest);

        }
        [HttpPost]
        public async Task<IActionResult> Delete(QLNghiPhepDeleteRequest request)
        {
            var result = await _qLNghiPhepApiClient.Delete(request.IDNP);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa nghỉ phép thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}