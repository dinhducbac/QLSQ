using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using QLSQ.AdminApp.Services;
using QLSQ.ViewModel.Catalogs.QLChucVu;

namespace QLSQ.AdminApp.Controllers
{
    public class QLChucVuController : Controller
    {
        public readonly IQLChucVuApiClient _qLChucVuApiClient;
        private readonly ISiQuanApiClient _siQuanApiClient;
        public readonly IQuanHamApiClient _quanHamApiClient;
        public readonly IBoPhanApiClient _boPhanApiClient;
        public readonly IChucVuApiClient _chucVuApiClient; 

        public QLChucVuController(IQLChucVuApiClient qLChucVuApiClient,IQuanHamApiClient quanHamApiClient, 
            IBoPhanApiClient boPhanApiClient, IChucVuApiClient chucVuApiClient, ISiQuanApiClient siQuanApiClient)
        {
            _qLChucVuApiClient = qLChucVuApiClient;
            _quanHamApiClient = quanHamApiClient;
            _boPhanApiClient = boPhanApiClient;
            _chucVuApiClient = chucVuApiClient;
            _siQuanApiClient = siQuanApiClient;
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
            if (ViewData["result"] != null)
            {
                ViewBag.Success = true;
                ViewBag.SuccessMessage = ViewData["result"];
            }
            return View(result.ResultObj);
        }
        [HttpGet]
        public async Task<JsonResult> Autocomplete(string prefix)
        {
            var listsq = await _siQuanApiClient.GetListSiQuanNotInQLChucVuAutocomplete(prefix);
            //var s = Json(listsq.ResultObj);
            foreach (var data in listsq.ResultObj)
            {
                var s = data.HoTen;
            }
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
            var getlListQuanHam = await _quanHamApiClient.GetAllWithoutPaging();
            qlcvCreateRequest.quanHamViewModels = getlListQuanHam.ResultObj;
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
                ViewData["result"] = "Tạo quản lý chức vụ sĩ quan thành công!";
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
    }
}