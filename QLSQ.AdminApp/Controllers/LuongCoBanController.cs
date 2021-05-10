using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QLSQ.ApiIntergration;
using QLSQ.ViewModel.Catalogs.LuongCoBan;

namespace QLSQ.AdminApp.Controllers.Component
{
    public class LuongCoBanController : Controller
    {
        public readonly ILuongCoBanApiClient _luongCoBanApiClient;
        public LuongCoBanController(ILuongCoBanApiClient luongCoBanApiClient)
        {
            _luongCoBanApiClient = luongCoBanApiClient;
        }
        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 5)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var lcbPagingRequest = new GetLuongCoBanPagingRequest()
            {
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _luongCoBanApiClient.GetAllWithPaging(lcbPagingRequest);
            if (result.IsSuccessed)
            {
                if(TempData["result"] != null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = ViewData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDLuongCB)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _luongCoBanApiClient.Details(IDLuongCB);
            if (result.IsSuccessed)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDLuongCB)
        {
            if(!ModelState.IsValid)
                return View(ModelState);
            var result = await _luongCoBanApiClient.Details(IDLuongCB);
            if (result.IsSuccessed)
            {
                var lcbUpdateRequest = new LuongCoBanUpdateRequest()
                {
                    IDLuongCB = result.ResultObj.IDLuongCB,
                    LuongCB = result.ResultObj.LuongCB
                };
                return View(lcbUpdateRequest);
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LuongCoBanUpdateRequest request)
        {
            var result = await _luongCoBanApiClient.Edit(request.IDLuongCB, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa lương cơ bản thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}