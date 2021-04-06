﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createRequest = new HeSoLuongTheoQuanHamCreateRequest()
            {
                quanHamViewModels = new List<QuanHamViewModel>()
            };
            var getqh = await _quanHamApiClient.GetListQuanHamNotInHeSoLuong();
            var test = getqh.IsSuccessed;
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Eror", "Home");
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
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}