using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLQuanHam;

namespace QLSQ.AdminApp.Controllers
{
    public class QLQuanHamController : Controller
    {
        public readonly IQLQuanHamApiClient _qLQuanHamApiClient;
        public readonly IQuanHamApiClient _quanHamApiClient;
        public readonly IHeSoLuongTheoQuanHamApiClient _heSoLuongTheoQuanHamApiClient;
        public readonly ISiQuanApiClient _siQuanApiClient;
        public QLQuanHamController(IQLQuanHamApiClient qLQuanHamApiClient, IQuanHamApiClient quanHamApiClient,
            IHeSoLuongTheoQuanHamApiClient heSoLuongTheoQuanHamApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _qLQuanHamApiClient = qLQuanHamApiClient;
            _quanHamApiClient = quanHamApiClient;
            _heSoLuongTheoQuanHamApiClient = heSoLuongTheoQuanHamApiClient;
            _siQuanApiClient = siQuanApiClient;
        }
        public async Task<IActionResult> Index(string keyword,int pageIndex = 1, int pageSize = 5)
        {
            var pageResult = new GetQLQuanHamPagingRequest()
            {
                keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var result = await _qLQuanHamApiClient.GetAllWithPaging(pageResult);
            if(result.ResultObj != null)
            {
                if(TempData["result"]!= null)
                {
                    ViewBag.Success = true;
                    ViewBag.SuccessMessage = TempData["result"];
                }
                return View(result.ResultObj);
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int IDQLQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var result = await _qLQuanHamApiClient.Details(IDQLQH);
            if (result.ResultObj != null)
                return View(result.ResultObj);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetHeSoLuongQHByIDQH(int IDQH)
        {
            var result = await _heSoLuongTheoQuanHamApiClient.GetHeSoLuongTheoQHByIDQH(IDQH);
            return Json(new SelectList(result.ResultObj, "IDHeSoLuongQH", "TenHeSoLuongQH"));
        }
        [HttpGet]
        public async Task<JsonResult> GetListSiQuanNotInQLQuanHamAutocomplete(string prefix)
        {
            var result = await _siQuanApiClient.GetListSiQuanNotInQLQuanHamAutocomplete(prefix);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public async Task<JsonResult> GetHeSoLuongTheoQHByIDHeSoLuongQH(int IDHeSoLuongQH)
        {
            var result = await _heSoLuongTheoQuanHamApiClient.GetHeSoLuongTheoQHByIDHeSoLuongQH(IDHeSoLuongQH);
            return Json(result.ResultObj);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
                return View(ModelState);

            var qlqhCreateRequest = new QLQuanHamCreateRequest()
            {
                quanHamViewModels = new List<ViewModel.Catalogs.QuanHam.QuanHamViewModel>(),
                heSoLuongTheoQuanHamViewModels = new List<ViewModel.Catalogs.HeSoLuongTheoQuanHam.HeSoLuongTheoQuanHamViewModel>(),
                HeSoLuong = (await _heSoLuongTheoQuanHamApiClient.GetHeSoLuongTheoQHByIDHeSoLuongQH(1)).ResultObj.HeSoLuong
            };
            var getlistqh = await _quanHamApiClient.GetAllWithoutPaging();
            qlqhCreateRequest.quanHamViewModels = getlistqh.ResultObj;
            var getlisthslqh = await _heSoLuongTheoQuanHamApiClient.GetHeSoLuongTheoQHByIDQH(1);
            qlqhCreateRequest.heSoLuongTheoQuanHamViewModels = getlisthslqh.ResultObj;
            return View(qlqhCreateRequest);
        }
        [HttpPost]
        public async Task<IActionResult>Create(QLQuanHamCreateRequest request)
        {
            var result = await _qLQuanHamApiClient.Create(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Tạo quân hàm cho sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int IDQLQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlqhViewModel = await _qLQuanHamApiClient.Details(IDQLQH);
            var qlqhUpdateRequest = new QLQuanHamUpdateRequest()
            {
                IDQLQH = qlqhViewModel.ResultObj.IDQLQH,
                IDSQ = qlqhViewModel.ResultObj.IDSQ,
                HoTen = qlqhViewModel.ResultObj.HoTen,
                IDQH = qlqhViewModel.ResultObj.IDQH,
                IDHeSoLuongQH = qlqhViewModel.ResultObj.IDHeSoLuongQH,
                HeSoLuong = qlqhViewModel.ResultObj.HeSoLuong,
                quanHamViewModels = new List<ViewModel.Catalogs.QuanHam.QuanHamViewModel>(),
                heSoLuongTheoQuanHamViewModels = new List<ViewModel.Catalogs.HeSoLuongTheoQuanHam.HeSoLuongTheoQuanHamViewModel>()
            };
            var qhvm = await _quanHamApiClient.GetAllWithoutPaging();
            qlqhUpdateRequest.quanHamViewModels = qhvm.ResultObj;
            var hslqhvm = await _heSoLuongTheoQuanHamApiClient.GetHeSoLuongTheoQHByIDQH(qlqhUpdateRequest.IDQH);
            qlqhUpdateRequest.heSoLuongTheoQuanHamViewModels = hslqhvm.ResultObj;
            return View(qlqhUpdateRequest);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(QLQuanHamUpdateRequest request)
        {
            var result = await _qLQuanHamApiClient.Edit(request.IDQLQH, request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Sửa quân hàm của sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int IDQLQH)
        {
            if (!ModelState.IsValid)
                return View(ModelState);
            var qlqhvm = await _qLQuanHamApiClient.Details(IDQLQH);
            var qlqhUpdateRequest = new QLQuanHamDeleteRequest()
            {
                IDQLQH = qlqhvm.ResultObj.IDQLQH,
                IDSQ = qlqhvm.ResultObj.IDSQ,
                HoTen = qlqhvm.ResultObj.HoTen,
                IDQH = qlqhvm.ResultObj.IDQH,
                TenQH = qlqhvm.ResultObj.TenQH,
                IDHeSoLuongQH = qlqhvm.ResultObj.IDHeSoLuongQH,
                TenHeSoLuongQH = qlqhvm.ResultObj.TenHeSoLuongQH,
                HeSoLuong = qlqhvm.ResultObj.HeSoLuong
            };
            return View(qlqhUpdateRequest);
        }
        public async Task<IActionResult> Delete(QLQuanHamDeleteRequest request)
        {
            var result = await _qLQuanHamApiClient.Delete(request.IDQLQH);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Xóa quân hàm của sĩ quan thành công!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error", "Home");
        }
    }
}